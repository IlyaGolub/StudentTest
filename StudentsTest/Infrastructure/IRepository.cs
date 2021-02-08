using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace StudentsTest.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> All();
        Task<T> Add(T entity);
        Task<T> Update(T current);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entitys);
        void AddRange(IEnumerable<T> entitys);
        Task SaveAsync();

    }
}
