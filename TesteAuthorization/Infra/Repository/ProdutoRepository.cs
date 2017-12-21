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
    public class ProdutoRepository : GenericRepository<Produto>
    {

        public IQueryable<Produto> GetById(int id)
        {
            return _entities.Produto.Where(x => x.Id == id);
        }
    }
}