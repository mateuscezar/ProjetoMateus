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
        public IHttpActionResult Post(ClientePostDto dto)
        {
            _appService.Post(dto);
            return Ok();
        }

        [Authorize]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_appService.GetById(id));
        }

        [Authorize]
        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(ClienteDto dto)
        {
            _appService.Edit(dto);
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _appService.Delete(id);
            return Ok();
        }
    }
    
}