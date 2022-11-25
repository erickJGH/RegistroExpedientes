using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegistroExpedientes.Model
{
    public partial class ExpedientesContext : DbContext
    {
        public ExpedientesContext()
        {
        }

        public ExpedientesContext(DbContextOptions<ExpedientesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Expediente> Expedientes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Computos-03; Initial Catalog=Expedientes; Integrated Security=True; Connect Timeout=30;\nEncrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__787A433DC27A6E07");

                entity.ToTable("Departamento");

                entity.HasIndex(e => e.NombreDepartamento, "UN_Deparmento")
                    .IsUnique();

                entity.Property(e => e.NombreDepartamento).HasMaxLength(75);
            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.HasKey(e => e.IdExpediente)
                    .HasName("PK__Expedien__101235DAC9602DE5");

                entity.ToTable("Expediente");

                entity.HasIndex(e => e.CedulaoRnc, "UQ__Expedien__FEB26E7AD24F62D6")
                    .IsUnique();

                entity.Property(e => e.ApellidoBeneficiario).HasMaxLength(50);

                entity.Property(e => e.CedulaoRnc)
                    .HasMaxLength(15)
                    .HasColumnName("CedulaoRNC");

                entity.Property(e => e.DescripcionExpediente).HasMaxLength(300);

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.FechaDeEntrada).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("money");

                entity.Property(e => e.NombreBeneficiario).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.TipoExpediente).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6BFF15BDC");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Cedula, "UQ__Usuario__B4ADFE38CF75A4E3")
                    .IsUnique();

                entity.HasIndex(e => e.Usuario1, "UQ__Usuario__E3237CF77578A68F")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Cedula).HasMaxLength(15);

                entity.Property(e => e.Clave).HasMaxLength(50);

                entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.PersonCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PersonLastLogin).HasColumnType("datetime");

                entity.Property(e => e.Privilegio).HasMaxLength(25);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(25)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DepartamentUsuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
