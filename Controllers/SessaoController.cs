using AutoMapper;
using CinemaAPI.Data.Dtos.Sessao;
using CinemaAPI.Models;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDTO createSessao)
        {
            Sessao sessao = _mapper.Map<Sessao>(createSessao);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new {Id = sessao.Id}, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.First(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDTO sessaoDto = _mapper.Map<ReadSessaoDTO>(sessao);

                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}