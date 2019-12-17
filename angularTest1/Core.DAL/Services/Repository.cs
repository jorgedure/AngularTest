using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DAL.Interfaces;
using Core.Entities;

namespace Core.DAL.Services
{
    public class Repository<T> : IRepository<T> where T : TodoList
    {
        private readonly DbContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public Task<T> GetByIdAsync(string id)
        {
            return _context.Set<T>().FindAsync(id);
        }

        public string Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
            return entity.Id;
        }

        public Task<string> CreateAsync(T entity)
        {
            return Task.FromResult(Create(entity));
        }

        public Task<bool> CreateBatchAsync(IEnumerable<T> entities)
        {
            try
            {
                _context.ChangeTracker.AutoDetectChangesEnabled = false;
                foreach (var entity in entities)
                {
                    _context.Entry(entity).State = EntityState.Added;
                }
                return Task.FromResult(_context.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _context.ChangeTracker.AutoDetectChangesEnabled = true;
            }
        }

        public bool Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public Task<bool> UpdateAsync(T entity)
        {
            return Task.FromResult(Update(entity));
        }

        public Task<bool> UpdateBatchAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            return Task.FromResult(_context.SaveChanges() > 0);
        }

        public bool Deactivate(T entity)
        {
            entity.Active = false;
            return Update(entity);
        }

        public Task<bool> DeactivateAsync(T entity)
        {
            entity.Active = false;
            return UpdateAsync(entity);
        }

        public bool Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        public Task<bool> DeleteAsync(T entity)
        {
            return Task.FromResult(Delete(entity));
        }

        public void ChangeState(object entity, EntityState state)
        {
            _context.Entry(entity).State = state;
        }

        IQueryable<T> IRepository<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<string> IRepository<T>.CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<T>.CreateBatchAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<T>.UpdateBatchAsync(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<T>.DeactivateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<T>.DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
