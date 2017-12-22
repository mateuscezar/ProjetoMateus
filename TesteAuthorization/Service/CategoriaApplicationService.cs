using Domain.Models;
using Interface.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Dto;

namespace Interface.Service
{
    public class CategoriaApplicationService
    {
        private CategoriaRepository _repository = null;

        public CategoriaApplicationService()
        {
            _repository = new CategoriaRepository();
        }

        public List<CategoriaDto> GetAll()
        {
            return _repository.GetAll().Select(x => new CategoriaDto {
                Id = x.Id,
                Ativo = x.Ativo,
                DataCadastro = x.DataCadastro,
                Nome = x.Nome
            }).ToList();
        }

        public void Post(CategoriaDto dto)
        {
            if (dto == null)
                throw new Exception("Parâmetros inválidos");

            Categoria db = new Categoria
            {
                Ativo = dto.Ativo,
                DataCadastro = DateTime.Now,
                Nome = dto.Nome
            };

            _repository.Add(db);
            _repository.Commit();
        }

        public CategoriaDto GetById(int id)
        {
            return _repository.GetById(id).Select(x => new CategoriaDto {
                Nome = x.Nome,
                Ativo = x.Ativo,
                DataCadastro = x.DataCadastro,
                Id = x.Id
            }).FirstOrDefault();
        }

        public void Edit(CategoriaDto dto)
        {
            Categoria categoria = ValidaCategoria(dto.Id);

            categoria.Ativo = dto.Ativo;
            categoria.Nome = dto.Nome;

            _repository.Edit(categoria);
            _repository.Commit();
        }

        private Categoria ValidaCategoria(int idCategoria)
        {
            var categoria = _repository.GetById(idCategoria).FirstOrDefault();

            if (categoria == null)
                throw new Exception("Categoria inválida.");
            return categoria;
        }

        public void Delete(int id)
        {
            Categoria categoria = ValidaCategoria(id);

            _repository.Delete(categoria);
            _repository.Commit();
        }
    }
}