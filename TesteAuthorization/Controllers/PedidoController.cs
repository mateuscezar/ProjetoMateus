using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Interface.Infra.Repository;
using Interface.Service;

namespace Interface.Controllers
{
    [RoutePrefix("Pedido")]
    public class PedidoController : ApiController
    {
        private PedidoApplicationService _appService = null;

        public PedidoController()
        {
            _appService = new PedidoApplicationService();
        }

        [Authorize]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_appService.GetById(id));
        }

    }
    
}