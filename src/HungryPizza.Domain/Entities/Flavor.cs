using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Entities
{
    public class Flavor : BaseEntity
    {
        public Flavor(string description, decimal price)
        {
            Id = Guid.NewGuid();
            Description = description;
            Price = price;
        }

        public string Description { get;  }
        public decimal Price { get; }
        public List<PizzaFlavor> PizzaFlavors { get; }
    }
}
