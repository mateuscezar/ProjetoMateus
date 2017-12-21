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
    public class CarrinhoRepository : IDisposable
    {
        private Model _entities;


        public CarrinhoRepository()
        {
            _entities = new Model();
        }

        public void Add(Carrinho db)
        {
            _entities.Carrinho.Add(db);
        }

        public IQueryable<Carrinho> GetByIdCliente(int idCliente)
        {
            return _entities.Carrinho.Where(x => x.IdCliente == idCliente);
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}