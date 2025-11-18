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

    public virtual DbSet<ContatosLembrete> ContatosLembretes { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PK__Contatos__3213E83FCA3F5834");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefone");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Contatos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Contatos__Usuari__6477ECF3");
        });

        modelBuilder.Entity<ContatosLembrete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contatos__3213E83FC3883FB5");

            entity.ToTable("contatosLembretes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContatosId).HasColumnName("Contatos_id");
            entity.Property(e => e.LembretesId).HasColumnName("Lembretes_id");

            entity.HasOne(d => d.Contatos).WithMany(p => p.ContatosLembretes)
                .HasForeignKey(d => d.ContatosId)
                .HasConstraintName("FK__contatosL__Conta__693CA210");

            entity.HasOne(d => d.Lembretes).WithMany(p => p.ContatosLembretes)
                .HasForeignKey(d => d.LembretesId)
                .HasConstraintName("FK__contatosL__Lembr__68487DD7");
        });

        modelBuilder.Entity<Lembrete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lembrete__3213E83F329B2353");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lembrete1)
                .HasColumnType("text")
                .HasColumnName("lembrete");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Lembretes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Lembretes__Usuar__619B8048");
        });

        modelBuilder.Entity<Lugare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lugares__3213E83F1CB1850A");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<LugaresLembrete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__lugaresL__3213E83FED46BFAD");

            entity.ToTable("lugaresLembretes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LembretesId).HasColumnName("Lembretes_id");
            entity.Property(e => e.LugaresId).HasColumnName("Lugares_id");

            entity.HasOne(d => d.Lembretes).WithMany(p => p.LugaresLembretes)
                .HasForeignKey(d => d.LembretesId)
                .HasConstraintName("FK__lugaresLe__Lembr__6D0D32F4");

            entity.HasOne(d => d.Lugares).WithMany(p => p.LugaresLembretes)
                .HasForeignKey(d => d.LugaresId)
                .HasConstraintName("FK__lugaresLe__Lugar__6C190EBB");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F44FB5001");

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
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("senha");
        });

        modelBuilder.Entity<UsuarioLugare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarioL__3213E83F584D043E");

            entity.ToTable("usuarioLugares");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LugaresId).HasColumnName("Lugares_id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Lugares).WithMany(p => p.UsuarioLugares)
                .HasForeignKey(d => d.LugaresId)
                .HasConstraintName("FK__usuarioLu__Lugar__6FE99F9F");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioLugares)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__usuarioLu__Usuar__70DDC3D8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
