using Domain.Models;
using Interface.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Dto;

namespace Interface.Service
{
    public class CarrinhoApplicationService
    {
        private CarrinhoRepository _repositoryCarrinho = null;
        private ClienteRepository _repositoryCliente = null;
        private ProdutoRepository _repositoryProduto = null;
        private PedidoRepository _repositoryPedido = null;
        private CarrinhoItensRepository _repositoryCarrinhoItens = null;

        public CarrinhoApplicationService()
        {
            _repositoryCarrinho = new CarrinhoRepository();
            _repositoryCliente = new ClienteRepository();
            _repositoryProduto = new ProdutoRepository();
            _repositoryPedido = new PedidoRepository();
            _repositoryCarrinhoItens = new CarrinhoItensRepository();
        }

        public void AdicionarProduto(AdicionarCarrinhoDto dto)
        {
            Produto produto = ValidaProduto(dto.IdProduto);

            Cliente cliente = ValidaCliente(dto.IdCliente);

            bool isEdit = true;

            var carrinho = _repositoryCarrinho.GetByIdCliente(dto.IdCliente).FirstOrDefault();

            if (carrinho == null)
            {
                carrinho = new Carrinho
                {
                    IdCliente = dto.IdCliente,
                    DataCadastro = DateTime.Now
                };

                isEdit = false;
            }

            carrinho.Total += produto.PrecoPromocional ?? produto.Preco;

            if (isEdit)
                _repositoryCarrinho.Edit(carrinho);
            else
                _repositoryCarrinho.Add(carrinho);

            _repositoryCarrinho.Commit();

            CarrinhoItens item = null;
            if (carrinho.Id > 0 && _repositoryCarrinhoItens.GetByCarrinhoProduto(carrinho.Id, dto.IdProduto).Any())
            {
                item = _repositoryCarrinhoItens.GetByCarrinhoProduto(carrinho.Id, dto.IdProduto).FirstOrDefault();
                item.Quantidade++;
                item.ValorTotalItem = (produto.PrecoPromocional ?? produto.Preco) * item.Quantidade;
                item.ValorUnitario = (produto.PrecoPromocional ?? produto.Preco);

                _repositoryCarrinhoItens.Edit(item);
                _repositoryCarrinhoItens.Commit();
            }
            else
            {
                item = new CarrinhoItens
                {
                    IdProduto = dto.IdProduto,
                    IdCarrinho = carrinho.Id,
                    DataCadastro = DateTime.Now,
                    Quantidade = 1,
                    ValorUnitario = (produto.PrecoPromocional ?? produto.Preco),
                    ValorTotalItem = (produto.PrecoPromocional ?? produto.Preco)
                };

                _repositoryCarrinhoItens.Add(item);
                _repositoryCarrinhoItens.Commit();
            }
            
        }

        private Produto ValidaProduto(int idProduto)
        {
            var produto = _repositoryProduto.GetById(idProduto).FirstOrDefault();

            if (produto == null)
                throw new Exception("Produto inválido.");
            return produto;
        }

        private Cliente ValidaCliente(int idCliente)
        {
            var cliente = _repositoryCliente.GetById(idCliente).FirstOrDefault();

            if (cliente == null)
                throw new Exception("Cliente inválido.");
            return cliente;
        }
    }
}