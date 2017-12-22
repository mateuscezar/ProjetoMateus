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
    [RoutePrefix("Produto")]
    public class ProdutoController : ApiController
    {
        private ProdutoApplicationService _appService = null;

        public ProdutoController()
        {
            _appService = new ProdutoApplicationService();
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_appService.GetAll());
        }

        [Authorize]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(ProdutoDto dto)
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
        public IHttpActionResult Put(ProdutoDto dto)
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