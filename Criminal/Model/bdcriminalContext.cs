using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Criminal.Model
{
    public partial class bdcriminalContext : DbContext
    {
        public bdcriminalContext()
        {
        }

        public bdcriminalContext(DbContextOptions<bdcriminalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agente> Agentes { get; set; } = null!;
        public virtual DbSet<Delincuente> Delincuentes { get; set; } = null!;
        public virtual DbSet<DelincuenteOrg> DelincuenteOrgs { get; set; } = null!;
        public virtual DbSet<Organizacion> Organizacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=Dino;database=bdcriminal", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Agente>(entity =>
            {
                entity.HasKey(e => e.Nif)
                    .HasName("PRIMARY");

                entity.ToTable("agente");

                entity.Property(e => e.Nif)
                    .ValueGeneratedNever()
                    .HasColumnName("nif");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroAgente).HasColumnName("numero_agente");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Delincuente>(entity =>
            {
                entity.HasKey(e => e.CodigoDelincuente)
                    .HasName("PRIMARY");

                entity.ToTable("delincuente");

                entity.HasIndex(e => e.CodigoAgente, "codigo_agente");

                entity.Property(e => e.CodigoDelincuente).HasColumnName("codigo_delincuente");

                entity.Property(e => e.Aliases)
                    .HasMaxLength(50)
                    .HasColumnName("aliases");

                entity.Property(e => e.CantidadDelitos).HasColumnName("cantidad_delitos");

                entity.Property(e => e.CodigoAgente).HasColumnName("codigo_agente");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsPeligroso).HasColumnName("es_peligroso");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(50)
                    .HasColumnName("especialidad");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.FechaPrimerDelito)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_primer_delito");

                entity.Property(e => e.IncrementoRecompensa)
                    .HasPrecision(10, 2)
                    .HasColumnName("incremento_recompensa");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.PaisOrigen)
                    .HasMaxLength(25)
                    .HasColumnName("pais_origen");

                entity.Property(e => e.RecompensaInicial)
                    .HasPrecision(10, 2)
                    .HasColumnName("recompensa_inicial");

                entity.Property(e => e.TipoDelincuente)
                    .HasMaxLength(25)
                    .HasColumnName("tipo_delincuente");

                entity.Property(e => e.TipoEstafador)
                    .HasMaxLength(50)
                    .HasColumnName("tipo_estafador");

                entity.HasOne(d => d.CodigoAgenteNavigation)
                    .WithMany(p => p.Delincuentes)
                    .HasForeignKey(d => d.CodigoAgente)
                    .HasConstraintName("delincuente_ibfk_1");
            });

            modelBuilder.Entity<DelincuenteOrg>(entity =>
            {
                entity.ToTable("delincuente_org");

                entity.HasIndex(e => e.CodigoDelincuente, "codigo_delincuente_");

                entity.HasIndex(e => e.CodigoOrg, "codigo_org_");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodigoDelincuente).HasColumnName("codigo_delincuente_");

                entity.Property(e => e.CodigoOrg).HasColumnName("codigo_org_");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_ingreso");

                entity.Property(e => e.FechaSalida)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_salida");

                entity.HasOne(d => d.CodigoDelincuenteNavigation)
                    .WithMany(p => p.DelincuenteOrgs)
                    .HasForeignKey(d => d.CodigoDelincuente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("delincuente_org_ibfk_2");

                entity.HasOne(d => d.CodigoOrgNavigation)
                    .WithMany(p => p.DelincuenteOrgs)
                    .HasForeignKey(d => d.CodigoOrg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("delincuente_org_ibfk_1");
            });

            modelBuilder.Entity<Organizacion>(entity =>
            {
                entity.HasKey(e => e.CodigoOrg)
                    .HasName("PRIMARY");

                entity.ToTable("organizacion");

                entity.Property(e => e.CodigoOrg).HasColumnName("codigo_org");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.Objetivo)
                    .HasMaxLength(50)
                    .HasColumnName("objetivo");

                entity.Property(e => e.Relaciones)
                    .HasMaxLength(50)
                    .HasColumnName("relaciones");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(25)
                    .HasColumnName("apellido");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .HasColumnName("nombre");

                entity.Property(e => e.Pass)
                    .HasMaxLength(50)
                    .HasColumnName("pass");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .HasColumnName("user_email");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
