using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Get(string login, string password);
        Task<User> Get(string login);
        Task<User> GetUserOrders(Guid id);
    }
}
