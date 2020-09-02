using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Infra.Contexts;

namespace HungryPizza.Domain.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly HungryPizzaContext _context;
        public OrderRepository(HungryPizzaContext context) : base(context)
        {
            _context = context;
        }
    }
}
