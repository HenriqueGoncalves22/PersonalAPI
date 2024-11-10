using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;
using PersonalApi.Models.Enuns;
using System.Text.Json.Serialization;

namespace PersonalApi.Models
{
    public class Acessorio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Modelo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Materiais { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
        public TipoAcessoriosEnum TipoAcessorios { get; set; }
        public int? ViolinoId { get; set; }
        [JsonIgnore]
        public Violino? Violino { get; set; }
    }
}