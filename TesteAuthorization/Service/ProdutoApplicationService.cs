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

        public ProdutoDto GetById(int id)
        {
            return _repository.GetById(id).Select(x => new ProdutoDto
            {
                Nome = x.Nome,
                Ativo = x.Ativo,
                Descricao = x.Descricao,
                Preco = x.Preco,
                PrecoPromocional = x.PrecoPromocional,
                Id = x.Id
            }).FirstOrDefault();
        }

        public void Edit(ProdutoDto dto)
        {
            Produto produto = ValidaProduto(dto.Id);

            produto.Ativo = dto.Ativo;
            produto.Descricao = dto.Descricao;
            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            produto.PrecoPromocional = dto.PrecoPromocional;

            _repository.Edit(produto);
            _repository.Commit();
        }

        private Produto ValidaProduto(int idProduto)
        {
            var produto = _repository.GetById(idProduto).FirstOrDefault();

            if (produto == null)
                throw new Exception("Produto inválido.");
            return produto;
        }

        public void Delete(int id)
        {
            Produto produto = ValidaProduto(id);

            _repository.Delete(produto);
            _repository.Commit();
        }
    }
}