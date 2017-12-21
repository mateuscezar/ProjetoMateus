using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PedidoDto
    {
        public int Id { get; set; }

        public double Valor { get; set; }

        public int IdCarrinho { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
