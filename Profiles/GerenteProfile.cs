using AutoMapper;
using CinemaAPI.Data.Dtos.Gerente;
using CinemaAPI.Models;
using FilmesAPI.Models;

namespace CinemaAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>()
                .ForMember(gerente => gerente.Cinemas, 
                opts => opts.MapFrom(gerente => gerente.Cinemas.Select
                (c => new {c.Id, c.Nome, c.Endereco, c.EnderecoId}))); //colocando informacoes redundantes para aparecer
        }
    }
}