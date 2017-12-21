using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TesteAuthorization.Infra.Repository
{
    public class CarrinhoItensRepository : IDisposable
    {
        private Model _entities;


        public CarrinhoItensRepository()
        {
            _entities = new Model();
        }

        public void Add(CarrinhoItens db)
        {
            _entities.CarrinhoItens.Add(db);
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}