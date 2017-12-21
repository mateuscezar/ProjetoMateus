namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Carrinho")]
    public partial class Carrinho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Carrinho()
        {
            CarrinhoItens = new HashSet<CarrinhoItens>();
        }

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCadastro { get; set; }

        public int IdCliente { get; set; }

        public double Total { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarrinhoItens> CarrinhoItens { get; set; }
    }
}
