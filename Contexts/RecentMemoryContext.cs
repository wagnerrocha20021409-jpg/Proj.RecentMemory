using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RecentMemory.Models;

namespace RecentMemory.Contexts;

public partial class RecentMemoryContext : DbContext
{
    public RecentMemoryContext()
    {
    }

    public RecentMemoryContext(DbContextOptions<RecentMemoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contato> Contatos { get; set; }

    public virtual DbSet<ContatoLembrete> ContatosLembretes { get; set; }

    public virtual DbSet<Lembrete> Lembretes { get; set; }

    public virtual DbSet<Lugare> Lugares { get; set; }

    public virtual DbSet<LugaresLembrete> LugaresLembretes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioLugare> UsuarioLugares { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RecentMemory;Integrated Security=True;");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contatos__3213E83FDE552535");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("telefone");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Contatos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Contatos__Usuari__4E88ABD4");
        });

        modelBuilder.Entity<ContatoLembrete>(entity =>
        {
            entity.ToTable("ContatoLembretes");

            entity.HasKey(e => e.Id).HasName("PK__ContatoL__3213E83FFC7AEB73");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContatosId).HasColumnName("Contatos_id");
            entity.Property(e => e.LembretesId).HasColumnName("Lembretes_id");

            entity.HasOne(d => d.Contatos).WithMany(p => p.ContatoLembretes)
                .HasForeignKey(d => d.ContatosId)
                .HasConstraintName("FK__ContatoLe__Conta__5AEE82B9");

            entity.HasOne(d => d.Lembretes).WithMany(p => p.ContatoLembretes)
                .HasForeignKey(d => d.LembretesId)
                .HasConstraintName("FK__ContatoLe__Lembr__5BE2A6F2");
        });

        modelBuilder.Entity<Lembrete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lembrete__3213E83FF8E29A18");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataLembrete).HasColumnType("datetime");
            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Titulo).HasColumnType("text");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Lembretes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Lembretes__Usuar__4BAC3F29");
        });

        modelBuilder.Entity<Lugare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lugares__3213E83F7BAD64EB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<LugaresLembrete>(entity =>
        {
            entity.ToTable("LugaresLembretes");

            entity.HasKey(e => e.Id).HasName("PK__LugaresL__3213E83F3D63D162");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LembretesId).HasColumnName("Lembretes_id");
            entity.Property(e => e.LugaresId).HasColumnName("Lugares_id");

            entity.HasOne(d => d.Lembretes).WithMany(p => p.LugaresLembretes)
                .HasForeignKey(d => d.LembretesId)
                .HasConstraintName("FK__LugaresLe__Lembr__5812160E");

            entity.HasOne(d => d.Lugares).WithMany(p => p.LugaresLembretes)
                .HasForeignKey(d => d.LugaresId)
                .HasConstraintName("FK__LugaresLe__Lugar__571DF1D5");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FCF4A5AAA");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("senha");
        });

        modelBuilder.Entity<UsuarioLugare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UsuarioL__3213E83F6EEF66FE");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LugaresId).HasColumnName("Lugares_id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Lugares).WithMany(p => p.UsuarioLugares)
                .HasForeignKey(d => d.LugaresId)
                .HasConstraintName("FK__UsuarioLu__Lugar__5441852A");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioLugares)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__UsuarioLu__Usuar__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    internal void SaveChanges()
    {
        throw new NotImplementedException();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
