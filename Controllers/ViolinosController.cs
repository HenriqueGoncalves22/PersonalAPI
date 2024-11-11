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
using Microsoft.AspNetCore.Mvc;
using PersonalApi.Data;
using PersonalApi.Models.Enuns;
using PersonalApi.Controllers;

namespace PersonalApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ViolinosController : ControllerBase
    {
        private readonly DataContext _context;
        public ViolinosController(DataContext context)
        {
            _context = context;
        }
        private static List<Violino> violinos = new List<Violino>()
        {
            new Violino() {Id = 1, Marca = "Eagles", Modelo = "CV-12", Descricao = "Queixeira, estandarte, cravelhas e botão: Ébano Encordoamento: M Calixto Arco de crina natural e madeira maçaranduba Estojo Gota  Ajuste Profissional (cavalete original, alma, pestana, cravelhas" ,Materiais = "Violino: Abeto e Atiro.  Ébano Arco:Maçaranduba", Valor = 1283.85, UsuarioId = 1}

        };
        
        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Violino V = violinos[0];
            return Ok(V);
        }
        
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(violinos);
        }

        [HttpGet("GetAcessorios")]
        public async Task<IActionResult> GetAcessoriosAsync()
        {
            try
            {
                List<Acessorio> acessorios = new List<Acessorio>();
                acessorios = await _context.TB_ACESSORIOS.ToListAsync();
                return Ok(acessorios);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(violinos.FirstOrDefault(vi => vi.Id == id));
        }

        [HttpPost("NovoViolino")]
        public IActionResult AddViolino(Violino novoViolino)
        {
            violinos.Add(novoViolino);
            return Ok(violinos);
        }

        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem()
        {
            List<Violino> listaFinal = violinos.OrderBy(v => v.Valor).ToList();
            return Ok(listaFinal);
        }

        [HttpGet("GetContagem")]
        public IActionResult GetQuantidade()
        {
            return Ok("Quantidade de violinos: " + violinos.Count);
        }

        [HttpDelete("(id)")]
        public IActionResult Delete(int id)
        {
            violinos.RemoveAll(viol => viol.Id == id);
            return Ok(violinos);
        }
    }
}