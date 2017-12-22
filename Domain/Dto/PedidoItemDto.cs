using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PedidoItemDto
    {
        public double ValorTotal { get; set; }
        public double ValorUnidade { get; set; }
        public int Quantidade { get; set; }
        //public DateTime DataCadastro { get; set; }
        public string NomeProduto { get; set; }
    }
}
