﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Interface.Infra.Repository;
using Interface.Service;
using Domain.Dto;

namespace Interface.Controllers
{
    [RoutePrefix("Categoria")]
    public class CategoriaController : ApiController
    {
        private CategoriaApplicationService _appService = null;

        public CategoriaController()
        {
            _appService = new CategoriaApplicationService();
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_appService.GetAll());
        }

        [Authorize]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_appService.GetById(id));
        }

        [Authorize]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post(CategoriaDto dto)
        {
            _appService.Post(dto);

            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(CategoriaDto dto)
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