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
        [Route("Novo")]
        public IHttpActionResult Post(ProdutoDto dto)
        {
            _appService.Post(dto);

            return Ok();
        }

    }
    
}