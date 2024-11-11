using Microsoft.AspNetCore.Mvc;
using PersonalApi.Models;
using PersonalApi.Models.Enuns;
using PersonalApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        private static List<Acessorio> acessorios = new List<Acessorio>()
        {
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
        };

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Acessorio a = await _context.TB_ACESSORIOS.FirstOrDefaultAsync(aBusca => aBusca.Id == id);
                return Ok(a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
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
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add (Acessorio novoAcessorio)
        {
            try
            {               
                if(novoAcessorio.TipoAcessorios == 0)
                  throw new Exception("O Acessório deve ser especificado!");

                Violino? v = await _context.TB_VIOLINOS.FirstOrDefaultAsync(v => v.Id == novoAcessorio.ViolinoId);
                
                if(v == null)
                    throw new Exception("Não existe violino com id informado.");

                 Acessorio buscaAcessorio = await _context.TB_ACESSORIOS
                 .FirstOrDefaultAsync(a => a.ViolinoId == novoAcessorio.ViolinoId);

                if(buscaAcessorio != null)
                    throw new Exception("O Violino selecionado já contém um acessório atribuído a ele.");
                  
                await _context.TB_ACESSORIOS.AddAsync(novoAcessorio);
                await _context.SaveChangesAsync();
                return Ok(novoAcessorio.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Acessorio novoAcessorio)
        {
            try
            {
                _context.TB_ACESSORIOS.Update(novoAcessorio);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Acessorio aRemover = await _context.TB_ACESSORIOS.FirstOrDefaultAsync(v => v.Id == id);
                _context.TB_ACESSORIOS.Remove(aRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

    }
}