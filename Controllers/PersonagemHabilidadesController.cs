using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PersonagemHabilidadesController : ControllerBase
  {
    private readonly DataContext _context;
    public PersonagemHabilidadesController(DataContext context)
    {
      _context = context;
      
    }

    [HttpPost]
    public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade)
    {
      try
      {
        Personagem personagem = await _context.TB_PERSONAGENS
        .Include(p => p.Arma)
        .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
        .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

        if (personagem == null)
          throw new System.Exception("Personagem não encontrado para o Id Informado.");

        Habilidade habilidade = await _context.TB_HABILIDADES
                            .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

        if (habilidade == null)
          throw new System.Exception("Habilidade não encontrada.");

        PersonagemHabilidade ph = new PersonagemHabilidade();
        ph.Personagem = personagem;
        ph.Habilidade = habilidade;
        await _context.TB_PERSONAGENS_HABILIDADES.AddAsync(ph);
        int linhasAfetadas = await _context.SaveChangesAsync();

        return Ok(linhasAfetadas);

      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{personagemId}")]
    public async Task<IActionResult> GetPersonagemHabilidades(int personagemId)
    {
      try
      {
        List<PersonagemHabilidade> phLista = new List<PersonagemHabilidade>();
        phLista = await _context.TB_PERSONAGENS_HABILIDADES
        .Include(p => p.Personagem)
        .Include(p => p.Habilidade)
        .Where(p => p.Personagem.Id == personagemId).ToListAsync();
        return Ok(phLista);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }


    [HttpGet("GetHabilidades")]
    public async Task<IActionResult> GetPersonagemHabilidades()
    {
      try
      {
        List<Habilidade> habilidades = new List<Habilidade>();
        habilidades = await _context.TB_HABILIDADES.ToListAsync();
        return Ok(habilidades);

      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }


    [HttpPost("DeletePersonagemHabilidade")]
    public async Task<IActionResult> DeletePersonagemHabilidade(PersonagemHabilidade pH)
    {
      try
      {
        PersonagemHabilidade personagemHabilidade = await _context.TB_PERSONAGENS_HABILIDADES
            .FirstOrDefaultAsync(ph => ph.PersonagemId == ph.PersonagemId && ph.HabilidadeId == ph.HabilidadeId);

        if (personagemHabilidade == null)
        {
          throw new System.Exception("PersonagemHabilidade não encontrada");
        }

        _context.TB_PERSONAGENS_HABILIDADES.Remove(personagemHabilidade);

        await _context.SaveChangesAsync();

        return Ok("PersonagemHabilidade removida com sucesso");
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}