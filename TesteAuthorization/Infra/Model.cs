namespace Interface.Infra
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Models;

    public partial class Model : DbContext, IDisposable
    {
        public Model()
            : base("name=AuthContext")
        {
        }

        public virtual DbSet<Carrinho> Carrinho { get; set; }
        public virtual DbSet<CarrinhoItens> CarrinhoItens { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoItens> PedidoItens { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrinho>()
                .HasMany(e => e.CarrinhoItens)
                .WithRequired(e => e.Carrinho)
                .HasForeignKey(e => e.IdCarrinho)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CarrinhoItens>()
            //    .HasMany(e => e.Pedido)
            //    .WithRequired(e => e.CarrinhoItens)
            //    .HasForeignKey(e => e.IdCarrinhoItens)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.ProdutoCategoria)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.IdCategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Carrinho)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.PedidoItens)
                .WithRequired(e => e.Pedido)
                .HasForeignKey(e => e.IdPedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.CarrinhoItens)
                .WithRequired(e => e.Produto)
                .HasForeignKey(e => e.IdProduto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.ProdutoCategoria)
                .WithRequired(e => e.Produto)
                .HasForeignKey(e => e.IdProduto)
                .WillCascadeOnDelete(false);
        }
    }
}
