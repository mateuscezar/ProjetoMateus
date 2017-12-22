using Domain.Dto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Interface.Infra.Repository;
using Interface.Service;

namespace Interface.Controllers
{
    [RoutePrefix("Carrinho")]
    public class CarrinhoController : ApiController
    {
        private CarrinhoApplicationService _appService = null;

        public CarrinhoController()
        {
            _appService = new CarrinhoApplicationService();
        }


        [Authorize]
        [Route("Adicionar")]
        [HttpPost]
        public IHttpActionResult AdicionarProduto(AdicionarCarrinhoDto dto)
        {
            _appService.AdicionarProduto(dto);

            return Ok();
        }

        [Authorize]
        [Route("Cliente/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetByCliente(int id)
        {
            return Ok(_appService.GetByCliente(id));
        }

    }
    
}