using MediatR;
using HungryPizza.Domain.Commands.Order;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Handlers.NewOrderHandler
{

    public class NewOrderHandler : IRequestHandler<NewOrderCommand, GenericCommandResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IFlavorRepository _flavorRepository;
        public NewOrderHandler(IOrderRepository orderRepository, IAddressRepository addressRepository,  IFlavorRepository flavorRepository)
        {
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
            _flavorRepository = flavorRepository;
        }

        public async Task<GenericCommandResult> Handle(NewOrderCommand request, CancellationToken cancellationToken)
        {
            if (request.Pizzas == null || !request.Pizzas.Any())
                return GenericCommandResult.Failure(new List<string> { ErrorMessages.EmptyPizzas });

            var validator = new NewOrderCommandValidator();
            var results = validator.Validate(request);
            if (!results.IsValid)
                return GenericCommandResult.Failure(results.Errors);


            List<Pizza> pizzas = new List<Pizza>();
            Order order;

            if (!request.IdUser.HasValue)
            {
                var validatoraddress = new AddressModelValidation();
                var resultaddress = validatoraddress.Validate(request.Address);
                if (!resultaddress.IsValid)
                    return GenericCommandResult.Failure(resultaddress.Errors);

                var address = new Address(request.Address.AddressName, request.Address.Number, request.Address.Complement, request.Address.Neighborhood, request.Address.ZipCode, request.Address.City, request.Address.State);
                await _addressRepository.Create(address);
                order = new Order(pizzas, request.IdUser, address.Id, DateTime.Now);
            }
            else
                order = new Order(pizzas, request.IdUser, null, DateTime.Now);

            var flavors = await _flavorRepository.Get();
            foreach (var p in request.Pizzas)
            {
                var pizza = new Pizza(order,flavors.Where(x => p.Flavors.Contains(x.Id)).Sum(s => s.Price) / p.Flavors.Count);
                pizza.PizzaFlavors = p.Flavors.Select(s => new PizzaFlavor(pizza.Id, s)).ToList();
                pizzas.Add(pizza);
            }
            
            await _orderRepository.Create(order);
            return GenericCommandResult.Success(order.Id);
        }
    }
}
