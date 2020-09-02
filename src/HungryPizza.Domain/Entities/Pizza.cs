using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Entities
{
    public class Pizza : BaseEntity
    {
        public Pizza()
        {
        }

        public Pizza(Order order,  decimal price)
        {
            Id = Guid.NewGuid();
            Order = order;
            Price = price;
        }

        public Order Order { get; }
        public List<PizzaFlavor> PizzaFlavors { get; set; }
        public decimal Price { get; }
    }
}
