using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace Interface.Infra.Repository
{
    public class PedidoRepository : GenericRepository<Pedido>
    {

        public IQueryable<Pedido> GetById(int id)
        {
            return _entities.Pedido.Include(x => x.PedidoItens).Where(x => x.Id == id);
        }

        public IQueryable<Pedido> GetByIdCarrinho(int idCarrinho)
        {
            return _entities.Pedido.Where(x => x.IdCarrinho == idCarrinho);
        }
    }
}