using AutoMapper;
using CinemaAPI.Data.Dtos.Sessao;
using CinemaAPI.Models;
using CinemaAPI.Services;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDTO createSessao)
        {
            ReadSessaoDTO readDto = _sessaoService.AdicionaSessao(createSessao);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new {Id = readDto.Id}, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDTO readDto = _sessaoService.RecuperaSessaoPorId(id);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }
        
    }
}