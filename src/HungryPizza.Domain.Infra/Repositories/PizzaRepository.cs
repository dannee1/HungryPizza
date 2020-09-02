using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Infra.Contexts;

namespace HungryPizza.Domain.Infra.Repositories
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        private readonly HungryPizzaContext _context;

        public PizzaRepository(HungryPizzaContext context) : base(context)
        {
            _context = context;
        }
    }
}
