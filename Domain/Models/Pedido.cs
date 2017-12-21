namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            PedidoItens = new HashSet<PedidoItens>();
        }

        [Key]
        public int Id { get; set; }

        public double Valor { get; set; }

        public int IdCarrinho { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCadastro { get; set; }

        //public virtual Carrinho Carrinho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoItens> PedidoItens { get; set; }
    }
}
