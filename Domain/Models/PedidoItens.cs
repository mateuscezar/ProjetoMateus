namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PedidoItens
    {
        [Key]
        public int Id { get; set; }

        public int IdPedido { get; set; }

        public double ValorTotal { get; set; }

        public double ValorUnidade { get; set; }

        public int Quantidade { get; set; }

        public int IdProduto { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCadastro { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
