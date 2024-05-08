using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RpgApi.Models;

namespace RpgApi
{
    public class Arma
    {
        public int Id { get; set;}

        public string Nome { get; set;}
        
        public int Dano { get; set;}

        public Personagem? Personagem { get; set; } = null!;

        public int PersonagemId { get; set; }
    }
}