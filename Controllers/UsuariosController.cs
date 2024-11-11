using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalApi.Models;
using PersonalApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalApi.Data;
using PersonalApi.Controllers;

namespace PersonalApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuariosController(DataContext context)
        {
            _context = context;
        }
        private async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.TB_USUARIOS.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try
            {
                if (await UsuarioExistente(user.Username))
                    throw new System.Exception("Nome de usuário já existe");

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.TB_USUARIOS.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

[HttpPut("AlterarSenha")]
public async Task<IActionResult> AlterarSenhaUsuario(Usuario credenciais)
{
      try
         {
             Usuario? usuario = await _context.TB_USUARIOS 
                .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

             if (usuario == null) 
                 throw new System.Exception("Usuário não encontrado.");

             Criptografia.CriarPasswordHash(credenciais.PasswordString, out byte[] hash, out byte[] salt);
            usuario.PasswordHash = hash;  
            usuario.PasswordSalt = salt; 

             _context.TB_USUARIOS.Update(usuario);
              int linhasAfetadas = await _context.SaveChangesAsync(); 
              return Ok(linhasAfetadas); 
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        
}

[HttpGet("GetAllUsers")]
public async Task<IActionResult> GetAll()
{
    
   try
     {
         List<Usuario> lista = await _context.TB_USUARIOS.ToListAsync();
         return Ok(lista);
   }
  catch (System.Exception ex)
      {
         return BadRequest(ex.Message + " - " + ex.InnerException);
     }
}

[HttpPost("AutenticarUsuario")]
public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
{
    try
    {
        var usuario = await _context.TB_USUARIOS
           .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

        if (usuario == null)
        {
            throw new System.Exception("Usuário não encontrado.");
        }
        else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
        {
            throw new System.Exception("Senha incorreta.");
        }
        else
        {
            usuario.DataAcesso = DateTime.Now;
            _context.TB_USUARIOS.Update(usuario);
            await _context.SaveChangesAsync();

            return Ok(usuario);
        }
    }
    catch (System.Exception ex)
    {
        return BadRequest(ex.Message + " - " + ex.InnerException?.Message);
    }
}

[HttpGet("{id}")]
public async Task<IActionResult> GetSingle (int id)
{
    try
    {
       Usuario? u = await _context.TB_USUARIOS
                .Include(vi => vi.Violinos)
                .FirstOrDefaultAsync(vi => vi.Id == id);
                return Ok(u);
   }
   catch (System.Exception ex)
     {
     return BadRequest(ex.Message);
     }

}
}
}