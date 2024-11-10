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

            modelBuilder.Entity<Acessorio>().HasData(new Acessorio
            {
                Id = 1,
                Nome = "Breu",
                Marca = "Pirastro",
                Modelo = "CV-52",
                Descricao = "Produzido na Alemanha, utilizando os melhores materiais, a marca Pirastro é dominante no segmento de...",
                Materiais = "Resina Natural de Pinho",
                TipoAcessorios = TipoAcessoriosEnum.Breu,
                Valor = 52.65,
                ViolinoId = 1
            });

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
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>()
            .HaveColumnType("varchar").HaveMaxLength(200);

            base.ConfigureConventions(configurationBuilder);
        }
    }
}