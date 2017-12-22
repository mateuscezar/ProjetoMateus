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
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public IQueryable<Categoria> GetById(int idCategoria)
        {
            return _entities.Categoria.Where(x => x.Id == idCategoria);
        }
    }
}