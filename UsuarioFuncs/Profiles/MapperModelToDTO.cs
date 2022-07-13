using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioFuncs.Data.DTO;
using UsuarioFuncs.Models;

namespace UsuarioFuncs.Profiles
{
    public class MapperModelToDTO : Profile
    {
        public MapperModelToDTO()
        { 
            CreateMap<CreateUsuarioDTO, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}