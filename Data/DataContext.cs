using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PersonalApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Cryptography;
using System.Data;
using PersonalApi.Utils;
using PersonalApi.Models.Enuns;


namespace PersonalApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Violino> TB_VIOLINOS { get; set; }
        public DbSet<Acessorio> TB_ACESSORIOS { get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Violino>().ToTable("TB_VIOLINOS");
            modelBuilder.Entity<Acessorio>().ToTable("TB_ACESSORIOS");
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

            modelBuilder.Entity<Usuario>()
            .HasMany(e => e.Violinos)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .IsRequired(false);

            modelBuilder.Entity<Violino>()
            .HasMany(e => e.Acessorios)
            .WithOne(e => e.Violino)
            .HasForeignKey(e => e.ViolinoId)
            .IsRequired(false);


            modelBuilder.Entity<Violino>().HasData(new Violino
            {
                Id = 1,
                Marca = "Eagles",
                Modelo = "CV-12",
                Descricao = "Queixeira, estandarte, cravelhas e botão: Ébano. Encordoamento: M Calixto. Arco de crina natural e madeira maçaranduba. Estojo Gota. Ajuste Profissional (cavalete original, alma, pestana, cravelhas)",
                Materiais = "Violino: Abeto e Atiro. Ébano. Arco: Maçaranduba",
                Valor = 1283.85,
                UsuarioId = 1
            });

            modelBuilder.Entity<Acessorio>().HasData
            (
            new Acessorio() {Id = 1, Nome ="Encordeamento", Marca = "Mauro Calixto", Modelo = "Padrão", Descricao = "As cordas Mauro Calixto são indicadas para qualquer estilo musical e procuradas iniciantes..." ,Materiais = "Núcleo de fibra sintética e Revestimento em aço", TipoAcessorios = TipoAcessoriosEnum.Encordeamento,Valor = 52 ,ViolinoId = 1},
            new Acessorio() {Id = 2, Nome ="Breu", Marca = "Pirastro", Modelo = "CV-52", Descricao = "Produzido na Alemanha se utilizando dos melhores materiais, a marca Pirastro é dominante no sergmento de..." ,Materiais = "Resina Natural de Pinho", TipoAcessorios = TipoAcessoriosEnum.Breu,Valor = 54.65 ,ViolinoId = 1},
            new Acessorio() {Id = 3, Nome ="Espaleira", Marca = "Lunnon", Modelo = "New", Descricao = "A espaleira Lunnon new apresenta design mais anatômico, que proporciona conforto, segurança e flexibilidade..." ,Materiais = "Plástico injetável", TipoAcessorios = TipoAcessoriosEnum.Espaleira,Valor = 36 ,ViolinoId = 1},
            new Acessorio() {Id = 4, Nome ="Cravelha", Marca = " NETO VIOLINOS", Modelo = "KIT 04 CRAVELHAS TAMARINDO PREMIUM", Descricao = "Produto Original da Fábrica, é necessário fazer furos e ajustes em um Luthier para que seja regulado em seu instrumento..." ,Materiais = "ÉBANO MESCLADO", TipoAcessorios = TipoAcessoriosEnum.Cravelha,Valor = 48.95 ,ViolinoId = 1},
            new Acessorio() {Id = 5, Nome ="Microafinador", Marca = "Mavis", Modelo = "Niquelado", Descricao = "Também pode ser chamado simplesmente de fixo, é uma peça que utilizamos para ajudar no momento de afinação..." ,Materiais = "Metal", TipoAcessorios = TipoAcessoriosEnum.Microafinador,Valor = 9.36 ,ViolinoId = 1},
            new Acessorio() {Id = 6, Nome ="Queixeira", Marca = "Mavis", Modelo = "Ébano", Descricao = "A queixeira é um acessório que se encaixa no extremo do corpo do violino ou da viola de arco. É um peça essencial..." ,Materiais = "Madeira de Ébano", TipoAcessorios = TipoAcessoriosEnum.Queixeira,Valor = 84.20 ,ViolinoId = 1},
            new Acessorio() {Id = 7, Nome ="Estandarte", Marca = "Mavis", Modelo = "Ébano", Descricao = "Disponíveis nos tamanhos:  1/10, 1/16, 1/4, 1/2, 3/4 e 4/4..." ,Materiais = "Madeira de Ébano", TipoAcessorios = TipoAcessoriosEnum.Estandarte,Valor = 50.94 ,ViolinoId = 1},
            new Acessorio() {Id = 8, Nome ="Cavalete", Marca = "Mavis", Modelo = "Madeira Mapple Mavis", Descricao = "Cavalete fabricado com madeira Maple de ótima qualidade, com a finalidade de proporcionar ao músico uma maior precisão..." ,Materiais = "Madeira Mapple", TipoAcessorios = TipoAcessoriosEnum.Cavalete, Valor = 12.47,ViolinoId = 1},
            new Acessorio() {Id = 9, Nome ="Arco", Marca = "Eagle", Modelo = "VWB44R", Descricao = "Descubra a qualidade excepcional do Arco Para Violino Eagle 4/4 VWB-44R Crina Animal Natural..." ,Materiais = "Hardwood no formato Octogonal (oitavado), Crina animal natural, Talão de ébano com madre-pérola Olho París incrustada", TipoAcessorios = TipoAcessoriosEnum.Arco,Valor = 89.10 ,ViolinoId = 1},
            new Acessorio() {Id = 10, Nome ="Espelho", Marca = "Mavis", Modelo = "Ébano", Descricao = "Disponíveis nos tamanhos: 1/16, 1/8, 1/4, 1/2 e 3/4..." ,Materiais = "Madeira de Ébano", TipoAcessorios = TipoAcessoriosEnum.Espelho,Valor = 90.44 ,ViolinoId = 1}
            );

            //Início da criação do usuário padrão.
            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuario>().HasData(user);
            base.OnModelCreating(modelBuilder);
        }
        
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
            .HaveColumnType("varchar").HaveMaxLength(200);

            base.ConfigureConventions(configurationBuilder);
        }
    }
}