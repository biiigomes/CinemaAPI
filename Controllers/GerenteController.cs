using AutoMapper;
using CinemaAPI.Data.Dtos.Gerente;
using CinemaAPI.Models;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Adicionagerente([FromForm] CreateGerenteDTO createGerente)
        {
            Gerente gerente = _mapper.Map<Gerente>(createGerente);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentePorId), new {Id = gerente.Id}, gerente);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.First(gerente => gerente.Id == id);
            if(gerente != null)
            {
                ReadGerenteDTO gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);
                return Ok(gerenteDTO);
            } 
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.First(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}