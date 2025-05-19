using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Modelos;

public partial class DbToDoContext : DbContext
{
    public DbToDoContext()
    {
    }

    public DbToDoContext(DbContextOptions<DbToDoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Todo> Todos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql($"Host={Environment.GetEnvironmentVariable("HOST")};Database={Environment.GetEnvironmentVariable("DATABASE")};Username={Environment.GetEnvironmentVariable("USERNAME")};Password={Environment.GetEnvironmentVariable("PASSWORD")}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("todo_pkey");

            entity.ToTable("todo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activado)
                .HasDefaultValue(true)
                .HasColumnName("activado");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Task).HasColumnName("task");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Todos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("todo_id_usuario_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.CorreoElectronico, "usuarios_correo_electronico_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContrasenaHash).HasColumnName("contrasena_hash");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FotoPerfil).HasColumnName("foto_perfil");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.UltimaVez)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("ultima_vez");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
