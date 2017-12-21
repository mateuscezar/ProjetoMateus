using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Interface.Infra.Repository;

namespace Interface.Controllers
{
    [RoutePrefix("Cliente")]
    public class ClienteController : ApiController
    {
        private ClienteRepository _repository = null;

        public ClienteController()
        {
            _repository = new ClienteRepository();
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_repository.GetAllClientes());
        }

    }
    
}