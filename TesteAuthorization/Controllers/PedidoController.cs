using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TesteAuthorization.Infra.Repository;

namespace TesteAuthorization.Controllers
{
    [RoutePrefix("Pedido")]
    public class PedidoController : ApiController
    {
        private PedidoRepository _repositoryPedido = null;

        public PedidoController()
        {
            _repositoryPedido = new PedidoRepository();
        }

        [Authorize]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_repositoryPedido.GetById(id).FirstOrDefault());
        }

    }
    
}