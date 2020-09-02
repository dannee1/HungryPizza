using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Models
{
    public class AddressModel
    {
        public string AddressName { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
