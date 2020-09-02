using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
        }

        public User(string name, string emailLogin, string password, string ddd, string phone, List<Address> addresses)
        {
            Name = name;
            EmailLogin = emailLogin;
            Password = password;
            DDD = ddd;
            Phone = phone;
            Addresses = addresses;
        }

        public string Name { get; }
        public string EmailLogin { get; }
        public string Password { get; }
        public string DDD { get; }
        public string Phone { get; }
        public List<Address> Addresses { get; }
        public List<Order> Orders { get; }
    }
}
