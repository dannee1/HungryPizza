using HungryPizza.Domain.Entities;
using HungryPizza.Domain.Interfaces.Repositories;
using HungryPizza.Domain.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza.Domain.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly HungryPizzaContext _context;
        public BaseRepository(HungryPizzaContext context)
        {
            _context = context;
        }
        public async Task Create(T obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T obj)
        {
             _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public Task<List<T>> Get()
        {
            return _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public Task<T> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
