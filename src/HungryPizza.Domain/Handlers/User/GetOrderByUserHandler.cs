using MediatR;
using HungryPizza.Domain.Commands.User;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Models;
using HungryPizza.Domain.Utils;
using HungryPizza.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Handlers.NewUserUserHandler
{

    public class GetOrderByUserHandler : IRequestHandler<GetOrderFromUserCommand, GenericCommandResult>
    {
        private readonly IUserRepository _userRepository;
        public GetOrderByUserHandler(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public async Task<GenericCommandResult> Handle(GetOrderFromUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserOrders(request.Id);
            var result = new OderUserModel
            {
                Orders = user.Orders.Select(p => new OrderModel
                {
                    OrderDateTime = p.OrderDateTime,
                    PriceTotal = p.Pizzas.Sum(s => s.Price),
                    Pizzas = p.Pizzas.Select(pi => new PizzaModel
                    {
                        Id = pi.Id,
                        Price = pi.Price,
                        PizzaFlavors = pi.PizzaFlavors.Select(ps => new FlavorModel
                        {
                            Description = ps.Flavor.Description,
                            Price = ps.Flavor.Price
                        }).ToList()
                    }).ToList()
                })
                .OrderByDescending(o => o.OrderDateTime)
                .ToList()
            };
            return GenericCommandResult.Success(result);
        }
    }
}
