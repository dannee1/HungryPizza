using HungryPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizza.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T obj);
        Task Update(T obj);
        Task Delete(T obj);
        Task<List<T>> Get();
        Task<T> Get(Guid id);
    }
}
