using AutoMapper;
using CinemaAPI.Data.Dtos.Gerente;
using CinemaAPI.Models;
using FilmesApi.Data;
using FluentResults;

namespace CinemaAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadGerenteDTO AdicionaGerente(CreateGerenteDTO createGerente)
        {
            Gerente gerente = _mapper.Map<Gerente>(createGerente);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDTO>(gerente);
        }

        public ReadGerenteDTO RecuperaGerentePorId(int id)
        {
            Gerente gerente = _context.Gerentes.First(gerente => gerente.Id == id);
            if(gerente != null)
            {
                ReadGerenteDTO gerenteDTO = _mapper.Map<ReadGerenteDTO>(gerente);
                return gerenteDTO;
            }
            return null;
        }

        public Result DeletaCinema(int id)
        {
            Gerente gerente = _context.Gerentes.First(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado");
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}