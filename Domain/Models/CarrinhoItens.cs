namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarrinhoItens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarrinhoItens()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        public int Id { get; set; }

        public int IdCarrinho { get; set; }

        public int IdProduto { get; set; }

        public double ValorUnitario { get; set; }

        public double ValorTotalItem { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCadastro { get; set; }

        public virtual Carrinho Carrinho { get; set; }

        public virtual Produto Produto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
