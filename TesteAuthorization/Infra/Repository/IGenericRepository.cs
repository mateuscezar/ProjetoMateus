using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Infra.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllReadOnly();

        void Add(T entity);

        void Add(List<T> entity);

        void Delete(T entity);

        void Delete(List<T> entity);

        void Edit(T entity);
    }
}