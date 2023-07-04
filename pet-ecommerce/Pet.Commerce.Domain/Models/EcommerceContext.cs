using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pet.Commerce.Domain.Models;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VendaProduto> VendaProdutos { get; set; }

    public virtual DbSet<Venda> Venda { get; set; }

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categoria_pkey");

            entity.ToTable("categoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(2000)
                .HasColumnName("descricao");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("produto_pkey");

            entity.ToTable("produto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.Descricao)
                .HasMaxLength(2000)
                .HasColumnName("descricao");
            entity.Property(e => e.Foto)
                .HasMaxLength(2000)
                .HasColumnName("foto");
            entity.Property(e => e.Preco)
                .HasPrecision(15, 2)
                .HasColumnName("preco");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("produto_categoria_id_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Login, "usuario_login_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Administrador).HasColumnName("administrador");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(1000)
                .HasColumnName("endereco");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Nome)
                .HasMaxLength(500)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(16)
                .HasColumnName("senha");
        });

        modelBuilder.Entity<VendaProduto>(entity =>
        {
            entity.HasKey(e => new { e.VendaId, e.ProdutoId }).HasName("venda_produto_pkey");

            entity.ToTable("venda_produto");

            entity.Property(e => e.VendaId).HasColumnName("venda_id");
            entity.Property(e => e.ProdutoId).HasColumnName("produto_id");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Preco)
               .HasPrecision(15, 2)
               .HasColumnName("preco");

            entity.HasOne(d => d.Produto).WithMany(p => p.VendaProdutos)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("venda_produto_produto_id_fkey");

            entity.HasOne(d => d.Venda).WithMany(p => p.VendaProdutos)
                .HasForeignKey(d => d.VendaId)
                .HasConstraintName("venda_produto_venda_id_fkey");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venda_pkey");

            entity.ToTable("venda");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataHora)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("data_hora");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Venda)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("venda_usuario_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
