using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Interface.Infra.Repository
{
    public class ProdutoRepository : IDisposable
    {
        private Model _entities;


        public ProdutoRepository()
        {
            _entities = new Model();
        }

        public List<Produto> GetAll()
        {
            return _entities.Produto.ToList();
        }

        public IQueryable<Produto> GetById(int id)
        {
            return _entities.Produto.Where(x => x.Id == id);
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}