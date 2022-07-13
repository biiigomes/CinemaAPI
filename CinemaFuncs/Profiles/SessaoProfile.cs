using AutoMapper;
using CinemaAPI.Data.Dtos.Sessao;
using CinemaAPI.Models;

namespace CinemaAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>();
                //    .ForMember(dto => dto.HorarioInicio, opts => opts
                //    .MapFrom(dto => dto.HorarioEncerramento
                //    .AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}