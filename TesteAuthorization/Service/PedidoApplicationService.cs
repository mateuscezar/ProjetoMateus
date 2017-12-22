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
        private CarrinhoRepository _repositoryCarrinho = null;
        private CarrinhoItensRepository _repositoryCarrinhoItens = null;
        private PedidoItensRepository _repositoryPedidoItens = null;
        private ProdutoRepository _repositoryProduto = null;

        public PedidoApplicationService()
        {
            _repository = new PedidoRepository();
            _repositoryCarrinho = new CarrinhoRepository();
            _repositoryCarrinhoItens = new CarrinhoItensRepository();
            _repositoryPedidoItens = new PedidoItensRepository();
            _repositoryProduto = new ProdutoRepository();
        }

        public PedidoDto GetById(int id)
        {
            var pedido = _repository.GetById(id).Select(x => new PedidoDto
            {
                Id = x.Id,
                Valor = x.Valor,
                DataCadastro = x.DataCadastro
            }).FirstOrDefault();

            var listaItens = _repositoryPedidoItens.GetByIdPedido(id).ToList();
            List<PedidoItemDto> listaItensDto = new List<PedidoItemDto>();
            foreach (var item in listaItens)
            {
                var produto = _repositoryProduto.GetById(item.IdProduto).FirstOrDefault();

                PedidoItemDto dto = new PedidoItemDto
                {
                    Quantidade = item.Quantidade,
                    ValorTotal = item.ValorTotal,
                    ValorUnidade = item.ValorUnidade,
                    NomeProduto = produto.Nome
                };

                listaItensDto.Add(dto);
            }

            pedido.Itens = listaItensDto;

            return pedido;
        }

        public void Post(PedidoPostDto dto)
        {
            if (_repository.GetByIdCarrinho(dto.IdCarrinho).Any())
                throw new Exception("Pedido já realizado");

            var carrinho = _repositoryCarrinho.GetById(dto.IdCarrinho).FirstOrDefault();

            if (carrinho == null)
                throw new Exception("Carrinho inválido.");

            var listaItensCarrinho = _repositoryCarrinhoItens.GetByCarrinho(carrinho.Id).ToList();

            Pedido pedido = new Pedido
            {
                DataCadastro = DateTime.Now,
                IdCarrinho = carrinho.Id,
                Valor = carrinho.Total
            };

            List<PedidoItens> listaItensPedido = new List<PedidoItens>();

            foreach (var itemCarrinho in listaItensCarrinho)
            {
                PedidoItens itemPedido = new PedidoItens
                {
                    DataCadastro = DateTime.Now,
                    Quantidade = itemCarrinho.Quantidade,
                    ValorTotal = itemCarrinho.ValorTotalItem,
                    ValorUnidade = itemCarrinho.ValorUnitario,
                    IdProduto = itemCarrinho.IdProduto,
                    Pedido = pedido
                };

                listaItensPedido.Add(itemPedido);
            }

            pedido.PedidoItens = listaItensPedido;

            _repository.Add(pedido);
            _repository.Commit();

        }
    }
}