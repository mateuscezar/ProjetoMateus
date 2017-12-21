using Domain.Models;
using Interface.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Dto;

namespace Interface.Service
{
    public class ClienteApplicationService
    {
        private ClienteRepository _repository = null;

        public ClienteApplicationService()
        {
            _repository = new ClienteRepository();
        }

        public List<Cliente> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public void Post(ClienteDto dto)
        {
            if (dto == null)
                throw new Exception("DTO Inválido.");

            Cliente db = new Cliente {
                DataCadastro = DateTime.Now,
                Email = dto.Email,
                Nome = dto.Nome
            };

            _repository.Add(db);
            _repository.Commit();
        }
    }
}