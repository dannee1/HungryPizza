using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Models
{
    public class PizzaModel
    {
        public Guid Id { get; set; }
        public List<FlavorModel> PizzaFlavors { get; set; }
        public decimal Price { get; set; }
    }
}
