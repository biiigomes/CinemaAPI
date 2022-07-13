using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Models;
using FilmesAPI.Data.Dtos;
using FluentResults;

namespace CinemaAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }
        public List<ReadEnderecoDto> RecuperaEnderecos()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            if(enderecos != null)
            {
                List<ReadEnderecoDto> readEnderecos = _mapper.Map<List<ReadEnderecoDto>>(enderecos);
                return readEnderecos;
            }
            return null;
        }

        public ReadEnderecoDto RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.First(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

                return enderecoDto;
            }
            return null;
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.First(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
        public Result DeleteFilme(int id)
        {
            Endereco endereco = _context.Enderecos.First(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}