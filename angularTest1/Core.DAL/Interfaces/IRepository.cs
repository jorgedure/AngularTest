using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.Interfaces
{
    public interface IRepository<T> 
    {
        IQueryable<T> GetAll();
        T GetById(string id);
        Task<T> GetByIdAsync(string id);
        string Create(T entity);
        Task<string> CreateAsync(T entity);
        Task<bool> CreateBatchAsync(IEnumerable<T> entities);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateBatchAsync(IEnumerable<T> entities);
        bool Deactivate(T entity);
        Task<bool> DeactivateAsync(T entity);
        bool Delete(T entity);
        Task<bool> DeleteAsync(T entity);
        void ChangeState(object entity, EntityState state);
    }
}
