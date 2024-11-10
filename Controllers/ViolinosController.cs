using Microsoft.AspNetCore.Mvc;
using PersonalApi.Models;

namespace PersonalApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ViolinosController : ControllerBase
    {
        private static List<Violino> violinos = new List<Violino>()
        {
            new Violino() {Id = 1, Marca = "Eagles", Modelo = "CV-12", Descricao = "Queixeira, estandarte, cravelhas e botão: Ébano Encordoamento: M Calixto Arco de crina natural e madeira maçaranduba Estojo Gota  Ajuste Profissional (cavalete original, alma, pestana, cravelhas" ,Materiais = "Violino: Abeto e Atiro.  Ébano Arco:Maçaranduba", Valor = 1283.85, UsuarioId = 1}

        };
    }
}