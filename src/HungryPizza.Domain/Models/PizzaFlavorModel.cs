using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;

namespace HungryPizza.Domain.Models
{
    public class PizzaFlavorModel
    {
        public int Ordem { get; set; }
        public List<Guid> Flavors { get; set; }
    }
}
