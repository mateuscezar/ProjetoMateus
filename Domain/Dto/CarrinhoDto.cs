using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class CarrinhoDto
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public double Total { get; set; }
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public List<PedidoItemDto> Itens { get; set; }
    }
}
