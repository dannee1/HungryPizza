using Microsoft.EntityFrameworkCore;
using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Infra.Contexts;
using HungryPizza.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly HungryPizzaContext _context;
        public UserRepository(HungryPizzaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserOrders(Guid id)
        {
            return await _context.User
                .Include("Orders.Pizzas.PizzaFlavors.Flavor")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> Get(string login, string password)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.EmailLogin == login && u.Password == password);
        }

        public async Task<User> Get(string login)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.EmailLogin == login);
        }


    }
}
