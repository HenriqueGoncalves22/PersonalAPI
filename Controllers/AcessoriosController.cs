using Microsoft.AspNetCore.Mvc;
using PersonalApi.Models;
using PersonalApi.Models.Enuns;
using PersonalApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalApi.Utils;
using PersonalApi.Controllers;

namespace PersonalApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoriosController : ControllerBase
    {
        private readonly DataContext _context;
        public AcessoriosController(DataContext context)
        {
            _context = context;
        }

    [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                 Acessorio a = await _context.TB_ACESSORIOS
                .Include(a => a.TipoAcessorios)
                .FirstOrDefaultAsync(aBusca => aBusca.Id == id);

                return Ok(a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]

        public async Task<IActionResult> Get()
        {
            try
            {
                List<Acessorio> lista = await _context.TB_ACESSORIOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Acessorio novoAcessorio)
        {
            try
            {
                await _context.TB_ACESSORIOS.AddAsync(novoAcessorio);
                await _context.SaveChangesAsync();

                return Ok(novoAcessorio.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Acessorio novoAcessorio)
        {
            try
            {
                _context.TB_ACESSORIOS.Update(novoAcessorio);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Acessorio aRemover = await _context.TB_ACESSORIOS.FirstOrDefaultAsync(a => a.Id == id);

                _context.TB_ACESSORIOS.Remove(aRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> GetUsuario(string login)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.TB_USUARIOS //Busca o usuário no banco através do login
                .FirstOrDefaultAsync(x => x.Username.ToLower() == login.ToLower());
                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}