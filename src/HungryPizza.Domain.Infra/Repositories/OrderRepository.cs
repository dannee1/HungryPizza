using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Infra.Contexts;

namespace HungryPizza.Domain.Infra.Repositories
{
    public class addressRepository : BaseRepository<Address>, IAddressRepository
    {
        private readonly HungryPizzaContext _context;
        public addressRepository(HungryPizzaContext context) : base(context)
        {
            _context = context;
        }
    }
}
