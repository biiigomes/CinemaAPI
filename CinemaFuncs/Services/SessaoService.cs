using AutoMapper;
using CinemaAPI.Data.Dtos.Sessao;
using CinemaAPI.Models;
using FilmesApi.Data;

namespace CinemaAPI.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadSessaoDTO AdicionaSessao(CreateSessaoDTO createSessao)
        {
            Sessao sessao = _mapper.Map<Sessao>(createSessao);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDTO>(sessao);
        }

        public ReadSessaoDTO RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.First(sessao => sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDTO sessaoDto = _mapper.Map<ReadSessaoDTO>(sessao);

                return sessaoDto;
            }
            return null;
        }
    }
}