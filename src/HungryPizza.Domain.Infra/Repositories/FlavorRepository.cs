using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizza.Domain.Infra.Repositories
{
    public class FlavorRepository : BaseRepository<Flavor>, IFlavorRepository
    {
        private readonly HungryPizzaContext _context;

        public FlavorRepository(HungryPizzaContext context) : base(context)
        {
            _context = context;
        }
    }
}
