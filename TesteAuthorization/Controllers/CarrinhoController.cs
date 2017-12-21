using Domain.Dto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Interface.Infra.Repository;

namespace Interface.Controllers
{
    [RoutePrefix("Carrinho")]
    public class CarrinhoController : ApiController
    {
        private CarrinhoRepository _repositoryCarrinho = null;
        private ClienteRepository _repositoryCliente = null;
        private ProdutoRepository _repositoryProduto = null;
        private PedidoRepository _repositoryPedido = null;

        public CarrinhoController()
        {
            _repositoryCarrinho = new CarrinhoRepository();
            _repositoryCliente = new ClienteRepository();
            _repositoryProduto = new ProdutoRepository();
            _repositoryPedido = new PedidoRepository();
        }


        //[Authorize]
        [Route("Adicionar")]
        [HttpPost]
        public IHttpActionResult AdicionarProduto(CarrinhoDto dto)
        {
            var cliente = _repositoryCliente.GetById(dto.IdCliente).FirstOrDefault();

            if (cliente == null)
                throw new Exception("Cliente inválido.");


            var carrinho = _repositoryCarrinho.GetByIdCliente(dto.IdCliente).FirstOrDefault();

            if (carrinho == null)
            {
                carrinho = new Carrinho
                {
                    Cliente = cliente,
                    DataCadastro = DateTime.Now,
                    CarrinhoItens = new List<CarrinhoItens>()
                };
            }

            var produto = _repositoryProduto.GetById(dto.Produto.IdProduto).FirstOrDefault();

            if (produto == null)
                throw new Exception("Produto inválido.");

            CarrinhoItens item = new CarrinhoItens
            {
                Produto = produto,
                Carrinho = carrinho,
                Pedido = null,
                DataCadastro = DateTime.Now,
                Quantidade = dto.Produto.Quantidade,
                ValorUnitario = produto.Preco,
                ValorTotalItem = produto.Preco * dto.Produto.Quantidade
            };

            carrinho.CarrinhoItens.Add(item);

            _repositoryCarrinho.Add(carrinho);

            return Ok();
        }

        //[Authorize]
        //[Route("Novo")]
        //[HttpPost]
        //public IHttpActionResult NovoCarrinho(CarrinhoDto dto)
        //{
        //    var cliente = _repositoryCliente.GetById(dto.IdCliente).FirstOrDefault();
            

        //    if (cliente == null)
        //        throw new Exception("Cliente inválido.");


        //    Carrinho carrinho = new Carrinho {
        //        Cliente = cliente,
        //        DataCadastro = DateTime.Now,
        //        CarrinhoItens = new List<CarrinhoItens>()
        //    };

        //    Pedido pedido = new Pedido
        //    {
        //        DataCadastro = DateTime.Now,
        //        PedidoItens = new List<PedidoItens>()
        //    };

        //    double total = 0;
        //    foreach (var produtoDto in dto.Produtos)
        //    {
        //        var produto = _repositoryProduto.GetById(produtoDto.IdProduto).FirstOrDefault();

        //        if (produto == null)
        //            throw new Exception("Produto inválido.");

        //        CarrinhoItens item = new CarrinhoItens
        //        {
        //            Produto = produto,
        //            Carrinho = carrinho,
        //            Pedido = null,
        //            DataCadastro = DateTime.Now,
        //            Quantidade = produtoDto.Quantidade,
        //            ValorUnitario = produto.Preco,
        //            ValorTotalItem = produto.Preco * produtoDto.Quantidade
        //        };

        //        PedidoItens itemPedido = new PedidoItens {
        //            DataCadastro = DateTime.Now,
        //            Quantidade = produtoDto.Quantidade,
        //            ValorUnidade = produto.Preco,
        //            ValorTotal = produto.Preco * produtoDto.Quantidade,
        //            IdProduto = produtoDto.IdProduto
        //        };

        //        carrinho.CarrinhoItens.Add(item);
        //        pedido.PedidoItens.Add(itemPedido);

        //        total += item.ValorTotalItem;
        //    }

        //    carrinho.Total = total;

        //    _repositoryCarrinho.Add(carrinho);

        //    pedido.IdCarrinho = carrinho.Id;
        //    pedido.Valor = total;

        //    _repositoryPedido.Add(pedido);

        //    return Ok();
        //}

    }
    
}