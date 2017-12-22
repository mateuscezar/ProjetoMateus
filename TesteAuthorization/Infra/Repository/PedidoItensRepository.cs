using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Interface.Infra.Repository
{
    public class PedidoItensRepository : GenericRepository<PedidoItens>
    {
        public IQueryable<PedidoItens> GetByIdPedido(int idPedido)
        {
            return _entities.PedidoItens.Where(x => x.IdPedido == idPedido).AsNoTracking();
        }
    }
}