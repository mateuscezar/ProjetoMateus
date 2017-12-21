using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TesteAuthorization.Infra.Repository;

namespace TesteAuthorization.Controllers
{
    [RoutePrefix("Produto")]
    public class ProdutoController : ApiController
    {
        private ProdutoRepository _repository = null;

        public ProdutoController()
        {
            _repository = new ProdutoRepository();
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

    }
    
}