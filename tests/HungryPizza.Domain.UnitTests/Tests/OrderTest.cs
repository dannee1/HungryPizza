using HungryPizza.Domain.Commands.Order;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Handlers.NewOrderHandler;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Models;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HungryPizza.Domain.UnitTests.tests
{
    public class NewOrderTest
    {
        private readonly AddressModel _address;
        private readonly List<Flavor> _flavors;
        private readonly IOrderRepository _orderRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IFlavorRepository _flavorRepository;

        public NewOrderTest()
        {
            _orderRepository = Substitute.For<IOrderRepository>();
            _addressRepository = Substitute.For<IAddressRepository>();
            _flavorRepository = Substitute.For<IFlavorRepository>();
            _address = new AddressModel
            {
                AddressName = "Av Belvedere",
                Number = "750",
                Complement = "A6",
                Neighborhood = "Belvedere",
                ZipCode = "15056030",
                City = "São José do Rio Preto",
                State = "SP"
            };
            _flavors = new List<Flavor>
            {
                new Flavor("Pepperoni", 10),
                new Flavor("3 Queijos", 15)
            };

        }

        private async Task<GenericCommandResult> BaseRequest(AddressModel address)
        {
            var flavors = _flavors;
            var pizzas = new List<PizzaFlavorModel>
            {
                new PizzaFlavorModel{ Ordem = 0, Flavors = flavors.Select(x => x.Id).ToList()}
            };

            var test = new NewOrderHandler(_orderRepository, _addressRepository, _flavorRepository);
            await _addressRepository.Create(Arg.Any<Address>());
            await _orderRepository.Create(Arg.Any<Order>());
            _flavorRepository.Get().ReturnsForAnyArgs(flavors);
            var request = new NewOrderCommand(pizzas, null, address);
            var result = await test.Handle(request, CancellationToken.None);
            return result;
        }

        [Fact(DisplayName = "Unauthenticated-OK")]
        public async Task UnauthenticatedTestOk()
        {
            var address = _address;

            var result = await BaseRequest(address);
            Assert.True(result.Ok);
        }

        [Fact(DisplayName = "UnauthenticatedNoAddress-NOK")]
        public async Task NoAddressNok()
        {
            var address = _address;
            address.AddressName = null;

            var result = await BaseRequest(address);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "Address Name"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "UnauthenticatedNoNumber-NOK")]
        public async Task UnauthenticatedNoNumberNok()
        {
            var address = _address;
            address.Number = null;

            var result = await BaseRequest(address);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "Number"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "UnauthenticatedNoNeighborhood-NOK")]
        public async Task UnauthenticatedNoNeighborhoodNok()
        {
            var address = _address;
            address.Neighborhood = null;

            var result = await BaseRequest(address);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "Neighborhood"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "UnauthenticatedNoCity-NOK")]
        public async Task UnauthenticatedNoCityNok()
        {
            var address = _address;
            address.City = null;

            var result = await BaseRequest(address);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "City"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "UnauthenticatedNoState-NOK")]
        public async Task UnauthenticatedNoStateNok()
        {
            var address = _address;
            address.State = null;

            var result = await BaseRequest(address);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "State"), result.Errors.FirstOrDefault());
        }

        [Fact(DisplayName = "UnauthenticatedNoZipCode-NOK")]
        public async Task UnauthenticatedNoZipCodeNok()
        {
            var address = _address;
            address.ZipCode = null;

            var result = await BaseRequest(address);
            Assert.Equal(ErrorMessages.EmptyField.Replace("{PropertyName}", "Zip Code"), result.Errors.FirstOrDefault());
        }


        [Fact(DisplayName = "UnauthenticatedNoZipCodeMaxlen-NOK")]
        public async Task UnauthenticatedNoZipCodeMaxlenNok()
        {
            var address = _address;
            address.ZipCode = "23131231321321";

            var result = await BaseRequest(address);
            Assert.Equal(ErrorMessages.MaxLen.Replace("{PropertyName}", "Zip Code").Replace("{MaxLength}", "8"), result.Errors.FirstOrDefault());
        }

    }
}
