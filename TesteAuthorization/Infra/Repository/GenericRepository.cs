using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Interface.Infra.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Model _entities { get; set; }

        protected DbSet<T> _dbSet;

        private DbSet<T> GetDbSet()
        {
            if (_dbSet == null)
                _dbSet = _entities.Set<T>();
            return _dbSet;
        }

        public GenericRepository()
        {
            _entities = new Model();
            _dbSet = _entities.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return GetDbSet().AsQueryable();
        }

        public IQueryable<T> GetAllReadOnly()
        {
            return GetDbSet().AsNoTracking();
        }

        public virtual void Add(T entity)
        {
            GetDbSet().Add(entity);
        }

        public virtual void Add(List<T> entity)
        {
            GetDbSet().AddRange(entity);
        }

        public virtual void Delete(T entity)
        {
            GetDbSet().Remove(entity);
        }

        public void Delete(List<T> entity)
        {
            GetDbSet().RemoveRange(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public void Commit()
        {
            _entities.SaveChanges();
        }
    }
}