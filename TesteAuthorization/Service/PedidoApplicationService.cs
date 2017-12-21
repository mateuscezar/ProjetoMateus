using Domain.Models;
using Interface.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Dto;

namespace Interface.Service
{
    public class PedidoApplicationService
    {
        private PedidoRepository _repository = null;

        public PedidoApplicationService()
        {
            _repository = new PedidoRepository();
        }

        public PedidoDto GetById(int id)
        {
            return _repository.GetById(id).Select(x => new PedidoDto
            {
                Id = x.Id,
                DataCadastro = x.DataCadastro,
                IdCarrinho = x.IdCarrinho,
                Valor = x.Valor
            }).FirstOrDefault();
        }
    }
}