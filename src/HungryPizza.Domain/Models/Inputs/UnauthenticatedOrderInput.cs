using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Models.Inputs
{
    public class UnauthenticatedOrderInput : OrderInput
    {
        public UnauthenticatedOrderInput(List<PizzaFlavorModel> pizzas, AddressModel address) : base(pizzas)
        {
            Address = address;
        }

        public AddressModel Address { get; set; }
    }
}
