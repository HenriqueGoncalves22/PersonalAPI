using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;
using PersonalApi.Models;

namespace PersonalApi.Models
{
    public class AcessoriosViolino
    {
        public int ViolinoId { get; set;}
        public Violino Violino { get; set;} = null!;
        public int AcessorioId { get; set; } 
        public Acessorio acessorio { get; set;} = null!;

    }
}