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

        public List<ClienteDto> GetAll()
        {
            return _repository.GetAll().Select(x => new ClienteDto {
                DataCadastro = x.DataCadastro,
                Email = x.Email,
                Nome = x.Nome,
                Id = x.Id
            }).ToList();
        }

        public void Post(ClientePostDto dto)
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

        public void Edit(ClienteDto dto)
        {
            Cliente cliente = ValidaCliente(dto.Id);

            cliente.Nome = dto.Nome;
            cliente.Email = dto.Email;

            _repository.Edit(cliente);
            _repository.Commit();
        }

        private Cliente ValidaCliente(int idCliente)
        {
            var cliente = _repository.GetById(idCliente).FirstOrDefault();

            if (cliente == null)
                throw new Exception("Cliente inválido.");
            return cliente;
        }

        public void Delete(int id)
        {
            Cliente cliente = ValidaCliente(id);

            _repository.Delete(cliente);
            _repository.Commit();
        }
    }
}