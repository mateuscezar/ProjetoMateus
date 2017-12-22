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
    public class CarrinhoRepository : GenericRepository<Carrinho>
    {

        public IQueryable<Carrinho> GetByIdCliente(int idCliente)
        {
            return _entities.Carrinho.Include(x => x.Cliente).Where(x => x.IdCliente == idCliente);
        }

        public IQueryable<Carrinho> GetById(int idCarrinho)
        {
            return _entities.Carrinho.Where(x => x.Id == idCarrinho);
        }
    }
}