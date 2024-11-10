using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PersonalApi.Models;
using System.Text.Json.Serialization;

namespace PersonalApi.Models
{
    public class Violino
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Materiais { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
        public int? UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        public List<Acessorio> Acessorios { get; set; } = [];
    }
}