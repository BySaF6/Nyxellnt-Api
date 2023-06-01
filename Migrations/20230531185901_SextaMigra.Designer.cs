﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NyxellntAPI.Entities;

#nullable disable

namespace NyxellntAPI.Migrations
{
    [DbContext(typeof(NyxellntDb))]
    [Migration("20230531185901_SextaMigra")]
    partial class SextaMigra
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FestivalEntity", b =>
                {
                    b.Property<int>("idFestival")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idFestival"));

                    b.Property<string>("artistas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("localidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precioEntrada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("precioEntradaVip")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.Property<int>("stockVip")
                        .HasColumnType("int");

                    b.HasKey("idFestival");

                    b.ToTable("Festivales");
                });

            modelBuilder.Entity("MerchandisingEntity", b =>
                {
                    b.Property<int>("idMerchandising")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idMerchandising"));

                    b.Property<string>("descripcionProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idFestival")
                        .HasColumnType("int");

                    b.Property<byte[]>("imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("nombreProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precioProducto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("stockProducto")
                        .HasColumnType("int");

                    b.Property<string>("tipoProducto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idMerchandising");

                    b.ToTable("Merchandising");
                });

            modelBuilder.Entity("OperacionEntradasEntity", b =>
                {
                    b.Property<int>("idOperacionEntradas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idOperacionEntradas"));

                    b.Property<string>("fechaCompra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idFestival")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<int>("numEntradasCompradas")
                        .HasColumnType("int");

                    b.Property<int>("numEntradasVipCompradas")
                        .HasColumnType("int");

                    b.Property<decimal>("precioTotalEntradas")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idOperacionEntradas");

                    b.ToTable("OperacionesEntradas");
                });

            modelBuilder.Entity("OperacionMerchandisingEntity", b =>
                {
                    b.Property<int>("idOperacionMerchandising")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idOperacionMerchandising"));

                    b.Property<string>("fechaCompra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idFestival")
                        .HasColumnType("int");

                    b.Property<int>("idMerchandising")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.Property<int>("numProductosComprados")
                        .HasColumnType("int");

                    b.Property<decimal>("precioTotalProductos")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idOperacionMerchandising");

                    b.ToTable("OperacionesProductos");
                });

            modelBuilder.Entity("UsuarioEntity", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idUsuario"));

                    b.Property<string>("apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
