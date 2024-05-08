using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RpgApi.Models;
using RpgApi.Models.Enuns;


namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonagnesExercicioController : ControllerBase
    {
       
        private static List<Personagem> personagens = new List<Personagem>()
        {
        new Personagem() { Id = 1, Nome = "Frodo", PontosVida=90, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
        new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
        new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=60, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
        new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=40, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
        new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
        new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=50, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
        new Personagem() { Id = 7, Nome = "Radagast", PontosVida=35, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };
     
        
        [HttpGet("GetByNome/{Nome}")]
        public IActionResult GetByNome(string Nome)
        {
            List<Personagem> listanome = personagens.FindAll(person => person.Nome.Contains(Nome));
          

        if (listanome == null)
        {
            return BadRequest("Não foi possivel encontrar o personagem digitado, tente novamente.");
        }
        return Ok(listanome);

        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem novoPersonagem)
        {
            if (novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 30)
                return BadRequest("Inteligencia ou defesa não correspondem aos requisitos");

            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem novoPersonagemMago)
        {
            
            if (novoPersonagemMago.Classe == ClasseEnum.Mago)
            {
                if (novoPersonagemMago.Inteligencia < 35 )
                    return BadRequest("Inteligencia não corresponde aos requisitos");
                else
                    personagens.Add(novoPersonagemMago);
                    return Ok(personagens);
            }
            else
            {
            personagens.Add(novoPersonagemMago);
            return Ok(personagens);
            }
         }

       // [HttpGet("GetClerigoMago")]
        //public IActionResult GetClerigoMago()
      //  {
    //        
  //      }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            var Quantidadepers = personagens.Count;
            var somatoria = personagens.Sum(p => p.Inteligencia);

            var estatisticas = new 
            {   
                Somatoria_de_Inteligencia = somatoria, 
                Quantidade_de_Personagens = Quantidadepers
            };
            return Ok(estatisticas);
        }

        [HttpGet("GetByClasse")]
        public IActionResult GetByClasse(int id)
        {
            ClasseEnum classe = (ClasseEnum)id;
            var personagensByClasse = personagens.Where(p =>  p.Classe == classe).ToList();

         //  if (personagensByClasse == 0)
         //   {
         //       return NotFound(); // Retorna 404 se não encontrar nenhum personagem com a classe informada
         //   }

            return Ok(personagensByClasse);
        }
           
                   
           
           
           
           // List<Personagem> personagensByClasse = personagens.FindAll(tipo => (int) tipo.Classe == id).ToList();

           // return Ok(personagensByClasse);
        
    
    
        }
        
        
        
}



    
