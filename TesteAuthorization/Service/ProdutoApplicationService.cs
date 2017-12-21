using Domain.Models;
using Interface.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Dto;

namespace Interface.Service
{
    public class ProdutoApplicationService
    {
        private ProdutoRepository _repository = null;

        public ProdutoApplicationService()
        {
            _repository = new ProdutoRepository();
        }

        public List<ProdutoDto> GetAll()
        {
            return _repository.GetAll().Select(x => new ProdutoDto {
                Id = x.Id,
                Ativo = x.Ativo,
                Descricao = x.Descricao,
                Nome = x.Nome,
                Preco = x.Preco,
                PrecoPromocional = x.PrecoPromocional
            }).ToList();
        }

        public void Post(ProdutoDto dto)
        {
            if (dto == null)
                throw new Exception("Parâmetros inválidos");

            Produto db = new Produto {
                Ativo = dto.Ativo,
                Descricao = dto.Descricao,
                Nome = dto.Nome,
                Preco = dto.Preco,
                PrecoPromocional = dto.PrecoPromocional
            };

            _repository.Add(db);
            _repository.Commit();
        }
    }
}