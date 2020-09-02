using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Entities
{
    public class PizzaFlavor : BaseEntity
    {
        public PizzaFlavor()
        {
        }

        public PizzaFlavor(Guid idPizza, Guid idFlavor)
        {
            Id = Guid.NewGuid();
            IdPizza = idPizza;
            IdFlavor = idFlavor;
        }

       

        public Pizza Pizza { get;  }
        public Guid IdPizza { get; }
        public Flavor Flavor { get; }
        public Guid IdFlavor { get; }
    }
}
