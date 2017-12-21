using Domain.Models;
using System.Linq;

namespace Interface.Infra.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>
    {
        public IQueryable<Cliente> GetById(int id)
        {
            return _entities.Cliente.Where(x => x.Id == id);
        }
    }
}