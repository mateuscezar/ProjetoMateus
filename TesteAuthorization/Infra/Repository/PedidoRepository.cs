using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace TesteAuthorization.Infra.Repository
{
    public class PedidoRepository : IDisposable
    {
        private Model _entities;


        public PedidoRepository()
        {
            _entities = new Model();
        }

        public void Add(Pedido db)
        {
            _entities.Pedido.Add(db);
        }

        public IQueryable<Pedido> GetById(int id)
        {
            return _entities.Pedido.Include(x => x.PedidoItens).Where(x => x.Id == id);
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}