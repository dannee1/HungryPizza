using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Models.Inputs
{
    public class OrderInput
    {
        public OrderInput(List<PizzaFlavorModel> pizzas)
        {
            Pizzas = pizzas;
        }

        public List<PizzaFlavorModel> Pizzas { get; set; }
    }
}
