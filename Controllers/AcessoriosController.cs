using Microsoft.AspNetCore.Mvc;
using PersonalApi.Models;

namespace PersonalApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoriosController : ControllerBase
    {
        private static List<Acessorio> acessorios = new List<Acessorio>()
        {
            new Acessorio() {Id = 1, Nome ="Breu", Marca = "Pirastro", Modelo = "CV-52", Descricao = "Produzido na Alemanha se utilizando dos melhores materiais, a marca Pirastro é dominante no sergmento de..." ,Materiais = " Resina Natural de Pinho"}

        };
    }
}