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
    public class ClienteRepository : IDisposable
    {
        private Model _entities;


        public ClienteRepository()
        {
            _entities = new Model();
        }

        public List<Cliente> GetAllClientes()
        {
            return _entities.Cliente.ToList();
        }

        public IQueryable<Cliente> GetById(int id)
        {
            return _entities.Cliente.Where(x => x.Id == id);
        }

        public void Dispose()
        {
            _entities.Dispose();
        }
    }
}