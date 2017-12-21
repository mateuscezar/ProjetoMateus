using Domain.Dto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Interface.Infra.Repository;
using Interface.Service;

namespace Interface.Controllers
{
    [RoutePrefix("Carrinho")]
    public class CarrinhoController : ApiController
    {
        private CarrinhoApplicationService _appService = null;

        public CarrinhoController()
        {
            _appService = new CarrinhoApplicationService();
        }


        [Authorize]
        [Route("Adicionar")]
        [HttpPost]
        public IHttpActionResult AdicionarProduto(AdicionarCarrinhoDto dto)
        {
            _appService.AdicionarProduto(dto);

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