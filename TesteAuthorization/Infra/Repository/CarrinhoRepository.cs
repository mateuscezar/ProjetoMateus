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
    public class CarrinhoRepository : GenericRepository<Carrinho>
    {

        public IQueryable<Carrinho> GetByIdCliente(int idCliente)
        {
            return _entities.Carrinho.Where(x => x.IdCliente == idCliente);
        }
    }
}