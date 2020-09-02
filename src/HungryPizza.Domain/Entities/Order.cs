using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order() { }
        public Order(List<Pizza> pizzas, Guid? idUser, Guid? idaddress, DateTime orderDateTime)
        {
            Id = Guid.NewGuid();
            Pizzas = pizzas;
            IdUser = idUser;
            Idaddress = idaddress;
            OrderDateTime = orderDateTime;
        }

        public List<Pizza> Pizzas { get; }
        public Guid? IdUser { get; }
        public User User { get; }
        public Guid? Idaddress { get; }
        public DateTime OrderDateTime { get; }
    }
}
