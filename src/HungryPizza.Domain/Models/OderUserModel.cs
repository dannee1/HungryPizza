using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Models
{
    public class OderUserModel
    {
        public List<OrderModel> Orders { get; set; }
    }
}
