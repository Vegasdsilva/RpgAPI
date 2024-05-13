using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using RpgApi.Utils;

namespace RpgApi.Controllers
{
     public class ArmasController : ControllerBase
    {
    private readonly DataContext _context;
    public ArmasController(DataContext context)
        {
            _context = context;
        }
   
    private static List<Arma> armas = new List<Arma>()
    {
        new Arma() { Id = 1, Nome = "Taurus", Dano = 60},
        new Arma() { Id = 2, Nome = "Desert-Eagle", Dano = 100},
        new Arma() { Id = 3, Nome = "P90", Dano = 35},
        new Arma() { Id = 4, Nome = "M4", Dano = 70},
        new Arma() { Id = 5, Nome = "Magnum", Dano = 90},
        new Arma() { Id = 6, Nome = "Glock", Dano = 50},
        new Arma() { Id = 7, Nome = "Sniper", Dano = 110}
    };

    [HttpGet("GetAll")]
    public IActionResult Get()
    {
        return Ok(armas);
    }

    [HttpPost]
    public async  Task<IActionResult> Add(Arma novaArma)
    {
        try
        {
            if(novaArma.Dano == 0)
                throw new Exception("O dano da arma não pode ser 0");

            Personagem p = await _context.TB_PERSONAGENS
                .FirstOrDefaultAsync(p => p.Id == novaArma.PersonagemId);

            if(p == null)
                throw new Exception("Não existe personagem com o Id informado");

            await _context.TB_ARMAS.AddAsync(novaArma);
            await _context.SaveChangesAsync();

            return Ok(novaArma.Id);
        }
        catch(System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult UpdateArma(Arma a)
    {
        Arma ArmaAlterada = armas.Find(arm => arm.Id == a.Id);
        ArmaAlterada.Nome = a.Nome;
        ArmaAlterada.Dano = a.Dano;

        return Ok(armas);
    }

    [HttpGet("BuscaPorId/{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(armas.FirstOrDefault(armamento => armamento.Id == id));
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        armas.RemoveAll(arm => arm.Id == id);
        return Ok(armas);
    }


    }
    

}