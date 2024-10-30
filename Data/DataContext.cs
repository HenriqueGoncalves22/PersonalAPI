using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PersonalApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Cryptography;

namespace PersonalApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
public DbSet<Violino> TB_VIOLINOS { get; set; }
public DbSet<AcessoriosViolino> TB_ACESSORIOSVIOLINO { get; set; }
public DbSet<Acessorio> TB_ACESSORIOS {get; set;}
public DbSet<Usuario> TB_USUARIOS {get; set;}

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Violino>().ToTable("TB_VIOLINOS");
    modelBuilder.Entity<AcessoriosViolino>().ToTable("TB_ACESSORIOSVIOLINO");
    modelBuilder.Entity<Usuario>().ToTable("TB_ACESSORIOS");
    modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");

    modelBuilder.Entity<Usuario>()
    .HasMany(e => e.Violinos)
    .WithOne(e => e.Usuario)
    .HasForeignKey(e => e.UsuarioId)
    .IsRequired(false);

    modelBuilder.Entity<AcessoriosViolino>()
    .HasKey(ap => new {ap.AcessoriosViolinosId, ap.ViolinosId});

    modelBuilder.Entity<Violino>().HasData(new Violino
        {
            Id = 1,
            Marca = "Eagles",
            Modelo = "CV-12",
            Descricao = "Queixeira, estandarte, cravelhas e botão: Ébano. Encordoamento: M Calixto. Arco de crina natural e madeira maçaranduba. Estojo Gota. Ajuste Profissional (cavalete original, alma, pestana, cravelhas)",
            Materiais = "Violino: Abeto e Atiro. Ébano. Arco: Maçaranduba",
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
            ViolinoId = 1
        });

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
        .HaveColumnType("varchar")
        .HaveMaxLength(200);
}


      
        

       
    }
}