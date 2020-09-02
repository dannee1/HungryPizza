using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Models
{
    public class OrderModel
    {
        public DateTime OrderDateTime { get; set; }
        public List<PizzaModel> Pizzas { get; set; }
        public decimal PriceTotal { get; set; }
    }
}
