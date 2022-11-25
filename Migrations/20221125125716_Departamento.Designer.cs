﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroExpedientes.Model;

#nullable disable

namespace RegistroExpedientes.Migrations
{
    [DbContext(typeof(ExpedientesContext))]
    [Migration("20221125125716_Departamento")]
    partial class Departamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RegistroExpedientes.Model.Departamento", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamento"), 1L, 1);

                    b.Property<string>("NombreDepartamento")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("IdDepartamento")
                        .HasName("PK__Departam__787A433DC27A6E07");

                    b.HasIndex(new[] { "NombreDepartamento" }, "UN_Deparmento")
                        .IsUnique();

                    b.ToTable("Departamento", (string)null);
                });

            modelBuilder.Entity("RegistroExpedientes.Model.Expediente", b =>
                {
                    b.Property<int>("IdExpediente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdExpediente"), 1L, 1);

                    b.Property<string>("ApellidoBeneficiario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CedulaoRnc")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("CedulaoRNC");

                    b.Property<string>("DescripcionExpediente")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaDeEntrada")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Monto")
                        .HasColumnType("money");

                    b.Property<string>("NombreBeneficiario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TipoExpediente")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdExpediente")
                        .HasName("PK__Expedien__101235DAC9602DE5");

                    b.HasIndex(new[] { "CedulaoRnc" }, "UQ__Expedien__FEB26E7AD24F62D6")
                        .IsUnique();

                    b.ToTable("Expediente", (string)null);
                });

            modelBuilder.Entity("RegistroExpedientes.Model.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int")
                        .HasColumnName("idDepartamento");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PersonCreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("PersonLastLogin")
                        .HasColumnType("datetime");

                    b.Property<string>("Privilegio")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Usuario1")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Usuario");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuario__645723A6BFF15BDC");

                    b.HasIndex("IdDepartamento");

                    b.HasIndex(new[] { "Cedula" }, "UQ__Usuario__B4ADFE38CF75A4E3")
                        .IsUnique();

                    b.HasIndex(new[] { "Usuario1" }, "UQ__Usuario__E3237CF77578A68F")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("RegistroExpedientes.Model.Usuario", b =>
                {
                    b.HasOne("RegistroExpedientes.Model.Departamento", "IdDepartamentoNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdDepartamento")
                        .IsRequired()
                        .HasConstraintName("fk_DepartamentUsuario");

                    b.Navigation("IdDepartamentoNavigation");
                });

            modelBuilder.Entity("RegistroExpedientes.Model.Departamento", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}