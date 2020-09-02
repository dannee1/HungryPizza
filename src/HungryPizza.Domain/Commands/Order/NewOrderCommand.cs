using MediatR;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Models;
using System;
using System.Collections.Generic;

namespace HungryPizza.Domain.Commands.Order
{
    public class NewOrderCommand : IRequest<GenericCommandResult>
    {
        public NewOrderCommand(List<PizzaFlavorModel> pizzas, Guid? idUser, AddressModel address)
        {
            Pizzas = pizzas;
            IdUser = idUser;
            Address = address;
        }

        public List<PizzaFlavorModel> Pizzas { get; set; }
        public Guid? IdUser { get; set; }
        public AddressModel Address { get; set; }
    }
}
