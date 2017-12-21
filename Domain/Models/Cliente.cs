namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Carrinho = new HashSet<Carrinho>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCadastro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carrinho> Carrinho { get; set; }
    }
}
