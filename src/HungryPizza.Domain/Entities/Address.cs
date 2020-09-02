using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Entities
{
    public class Address : BaseEntity
    {
        public Address() { }
        public Address(string addressName, string number, string complement, string neighborhood, string zipcode, string city, string state)
        {
            Id = Guid.NewGuid();
            AddressName = addressName;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            ZipCode = zipcode;
            City = city;
            State = state;
        }

        public string AddressName { get; }
        public string Number { get; }
        public string Complement { get; }
        public string Neighborhood { get; }
        public string ZipCode { get; }
        public string City { get; }
        public string State { get; }
        public User User { get; }
        public Guid? IdUser { get; }
    }
}
