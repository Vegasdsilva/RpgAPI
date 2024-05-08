using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgApi.Models
{
  public class PersonagemHabilidade
  {
    public int PersonagemId { get; set; }

    public Personagem? Personagem { get; set; } = null;

    public int HabilidadeId { get; set; }

    public Habilidade? Habilidade { get; set; } = null;

    public static implicit operator PersonagemHabilidade(List<PersonagemHabilidade> v)
    {
      throw new NotImplementedException();
    }

    public static implicit operator PersonagemHabilidade(List<Habilidade?> v)
    {
      throw new NotImplementedException();
    }
  }
}