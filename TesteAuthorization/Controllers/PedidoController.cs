using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Interface.Infra.Repository;
using Interface.Service;
using Domain.Dto;

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
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_appService.GetById(id));
        }

        [Authorize]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(_appService.GetAll());
        }

        [Authorize]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(PedidoPostDto dto)
        {
            _appService.Post(dto);
            return Ok();
        }

    }
    
}