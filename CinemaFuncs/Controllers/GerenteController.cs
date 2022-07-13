using AutoMapper;
using CinemaAPI.Data.Dtos.Gerente;
using CinemaAPI.Models;
using CinemaAPI.Services;
using FilmesApi.Data;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromForm] CreateGerenteDTO createGerente)
        {
            ReadGerenteDTO readDto = _gerenteService.AdicionaGerente(createGerente);
            return CreatedAtAction(nameof(RecuperaGerentePorId), new {Id = readDto.Id}, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            ReadGerenteDTO readDTO = _gerenteService.RecuperaGerentePorId(id);
            if(readDTO != null) return Ok(readDTO);
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result resultado = _gerenteService.DeletaCinema(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}