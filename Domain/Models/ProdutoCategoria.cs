namespace Domain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProdutoCategoria")]
    public partial class ProdutoCategoria
    {
        [Key]
        public int Id { get; set; }

        public int IdCategoria { get; set; }

        public int IdProduto { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataCadastro { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
