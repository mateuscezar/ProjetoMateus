using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class CarrinhoDto
    {
        public int IdCliente { get; set; }
        public List<ProdutoDto> Produtos { get; set; }
    }
}
