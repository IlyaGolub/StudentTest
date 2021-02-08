using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsTest.Infrastructure
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly StudentContext context;

        public EfRepository(StudentContext context)
        {
            this.context = context;
        }

        public DbSet<T> All()
        {
            return context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<T> Update(T current)
        {
            context.Update(current);
            await SaveAsync();

            return current;
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await SaveAsync();
        }

        public void DeleteRange(IEnumerable<T> entitys)
        {
            context.Set<T>().RemoveRange(entitys);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<T> entitys)
        {
            context.Set<T>().AddRange(entitys);
        }
    }
}
