using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Interface.Controllers
{
    public class TesteController : ApiController
    {
        [HttpGet]
        [Route("api/v1/teste")]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            return Ok("teste");
        }
    }
}
