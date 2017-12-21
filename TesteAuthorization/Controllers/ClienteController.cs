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
    [RoutePrefix("Cliente")]
    public class ClienteController : ApiController
    {
        private ClienteApplicationService _appService = null;

        public ClienteController()
        {
            _appService = new ClienteApplicationService();
        }

        [Authorize]
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_appService.GetAll());
        }

        [Authorize]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(ClienteDto dto)
        {
            _appService.Post(dto);
            return Ok();
        }
    }
    
}