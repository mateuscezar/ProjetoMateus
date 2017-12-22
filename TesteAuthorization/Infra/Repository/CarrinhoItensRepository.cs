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
    public class CarrinhoItensRepository : GenericRepository<CarrinhoItens>
    {
        public IQueryable<CarrinhoItens> GetByCarrinhoProduto(int idCarrinho, int idProduto)
        {
            return _entities.CarrinhoItens.Where(x => x.IdCarrinho == idCarrinho && x.IdProduto == idProduto);
        }

        public IQueryable<CarrinhoItens> GetByCarrinho(int idCarrinho)
        {
            return _entities.CarrinhoItens.Where(x => x.IdCarrinho == idCarrinho);
        }
    }
}