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
    public class PedidoItensRepository : IDisposable
    {
        private Model _entities;


        public PedidoItensRepository()
        {
            _entities = new Model();
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}