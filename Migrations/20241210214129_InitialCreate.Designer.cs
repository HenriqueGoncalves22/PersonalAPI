﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalApi.Data;

#nullable disable

namespace PersonalAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241210214129_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersonalApi.Models.Acessorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Materiais")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<int>("TipoAcessorios")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<int?>("ViolinoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ViolinoId");

                    b.ToTable("TB_ACESSORIOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "As cordas Mauro Calixto são indicadas para qualquer estilo musical e procuradas iniciantes...",
                            Marca = "Mauro Calixto",
                            Materiais = "Núcleo de fibra sintética e Revestimento em aço",
                            Modelo = "Padrão",
                            Nome = "Encordeamento",
                            TipoAcessorios = 1,
                            Valor = 52.0,
                            ViolinoId = 1
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Produzido na Alemanha se utilizando dos melhores materiais, a marca Pirastro é dominante no sergmento de...",
                            Marca = "Pirastro",
                            Materiais = "Resina Natural de Pinho",
                            Modelo = "CV-52",
                            Nome = "Breu",
                            TipoAcessorios = 2,
                            Valor = 54.649999999999999,
                            ViolinoId = 1
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "A espaleira Lunnon new apresenta design mais anatômico, que proporciona conforto, segurança e flexibilidade...",
                            Marca = "Lunnon",
                            Materiais = "Plástico injetável",
                            Modelo = "New",
                            Nome = "Espaleira",
                            TipoAcessorios = 3,
                            Valor = 36.0,
                            ViolinoId = 1
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Produto Original da Fábrica, é necessário fazer furos e ajustes em um Luthier para que seja regulado em seu instrumento...",
                            Marca = " NETO VIOLINOS",
                            Materiais = "ÉBANO MESCLADO",
                            Modelo = "KIT 04 CRAVELHAS TAMARINDO PREMIUM",
                            Nome = "Cravelha",
                            TipoAcessorios = 4,
                            Valor = 48.950000000000003,
                            ViolinoId = 1
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Também pode ser chamado simplesmente de fixo, é uma peça que utilizamos para ajudar no momento de afinação...",
                            Marca = "Mavis",
                            Materiais = "Metal",
                            Modelo = "Niquelado",
                            Nome = "Microafinador",
                            TipoAcessorios = 5,
                            Valor = 9.3599999999999994,
                            ViolinoId = 1
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "A queixeira é um acessório que se encaixa no extremo do corpo do violino ou da viola de arco. É um peça essencial...",
                            Marca = "Mavis",
                            Materiais = "Madeira de Ébano",
                            Modelo = "Ébano",
                            Nome = "Queixeira",
                            TipoAcessorios = 6,
                            Valor = 84.200000000000003,
                            ViolinoId = 1
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "Disponíveis nos tamanhos:  1/10, 1/16, 1/4, 1/2, 3/4 e 4/4...",
                            Marca = "Mavis",
                            Materiais = "Madeira de Ébano",
                            Modelo = "Ébano",
                            Nome = "Estandarte",
                            TipoAcessorios = 7,
                            Valor = 50.939999999999998,
                            ViolinoId = 1
                        },
                        new
                        {
                            Id = 8,
                            Descricao = "Cavalete fabricado com madeira Maple de ótima qualidade, com a finalidade de proporcionar ao músico uma maior precisão...",
                            Marca = "Mavis",
                            Materiais = "Madeira Mapple",
                            Modelo = "Madeira Mapple Mavis",
                            Nome = "Cavalete",
                            TipoAcessorios = 8,
                            Valor = 12.470000000000001,
                            ViolinoId = 1
                        },
                        new
                        {
                            Id = 9,
                            Descricao = "Descubra a qualidade excepcional do Arco Para Violino Eagle 4/4 VWB-44R Crina Animal Natural...",
                            Marca = "Eagle",
                            Materiais = "Hardwood no formato Octogonal (oitavado), Crina animal natural, Talão de ébano com madre-pérola Olho París incrustada",
                            Modelo = "VWB44R",
                            Nome = "Arco",
                            TipoAcessorios = 9,
                            Valor = 89.099999999999994,
                            ViolinoId = 1
                        },
                        new
                        {
                            Id = 10,
                            Descricao = "Disponíveis nos tamanhos: 1/16, 1/8, 1/4, 1/2 e 3/4...",
                            Marca = "Mavis",
                            Materiais = "Madeira de Ébano",
                            Modelo = "Ébano",
                            Nome = "Espelho",
                            TipoAcessorios = 10,
                            Valor = 90.439999999999998,
                            ViolinoId = 1
                        });
                });

            modelBuilder.Entity("PersonalApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("TB_USUARIOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "seuEmail@gmail.com",
                            Latitude = -23.520024100000001,
                            Longitude = -46.596497999999997,
                            PasswordHash = new byte[] { 167, 56, 235, 8, 246, 13, 41, 20, 26, 251, 137, 92, 171, 166, 251, 183, 222, 23, 178, 38, 155, 169, 91, 99, 255, 80, 4, 12, 143, 17, 222, 120, 134, 113, 117, 199, 68, 64, 22, 73, 6, 141, 128, 163, 227, 67, 48, 77, 139, 101, 176, 159, 192, 101, 130, 136, 184, 213, 195, 67, 18, 145, 225, 147 },
                            PasswordSalt = new byte[] { 148, 22, 247, 104, 111, 138, 108, 137, 119, 227, 83, 39, 220, 210, 200, 107, 12, 40, 231, 182, 147, 126, 48, 98, 168, 191, 236, 91, 223, 168, 236, 244, 74, 151, 197, 182, 0, 104, 52, 111, 14, 3, 70, 209, 159, 105, 184, 213, 131, 207, 211, 221, 45, 72, 220, 81, 130, 45, 85, 238, 110, 97, 9, 143, 6, 70, 219, 127, 32, 45, 160, 30, 39, 133, 146, 197, 122, 215, 101, 245, 250, 102, 68, 233, 238, 198, 54, 144, 185, 230, 118, 52, 210, 177, 138, 142, 239, 147, 154, 54, 128, 124, 104, 210, 136, 94, 129, 92, 229, 178, 185, 167, 17, 195, 215, 29, 151, 11, 210, 179, 38, 237, 72, 158, 101, 28, 111, 101 },
                            Perfil = "Admin",
                            Username = "UsuarioAdmin"
                        });
                });

            modelBuilder.Entity("PersonalApi.Models.Violino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Materiais")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("TB_VIOLINOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Queixeira, estandarte, cravelhas e botão: Ébano. Encordoamento: M Calixto. Arco de crina natural e madeira maçaranduba. Estojo Gota. Ajuste Profissional (cavalete original, alma, pestana, cravelhas)",
                            Marca = "Eagles",
                            Materiais = "Violino: Abeto e Atiro. Ébano. Arco: Maçaranduba",
                            Modelo = "CV-12",
                            UsuarioId = 1,
                            Valor = 1283.8499999999999
                        });
                });

            modelBuilder.Entity("PersonalApi.Models.Acessorio", b =>
                {
                    b.HasOne("PersonalApi.Models.Violino", "Violino")
                        .WithMany("Acessorios")
                        .HasForeignKey("ViolinoId");

                    b.Navigation("Violino");
                });

            modelBuilder.Entity("PersonalApi.Models.Violino", b =>
                {
                    b.HasOne("PersonalApi.Models.Usuario", "Usuario")
                        .WithMany("Violinos")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PersonalApi.Models.Usuario", b =>
                {
                    b.Navigation("Violinos");
                });

            modelBuilder.Entity("PersonalApi.Models.Violino", b =>
                {
                    b.Navigation("Acessorios");
                });
#pragma warning restore 612, 618
        }
    }
}