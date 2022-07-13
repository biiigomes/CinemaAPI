using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioFuncs.Data.DTO;
using UsuarioFuncs.Data.Request;
using UsuarioFuncs.Models;

namespace UsuarioFuncs.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
 
        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }
        public Result CadastraUsuario(CreateUsuarioDTO createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto); 
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager
                .CreateAsync(usuarioIdentity, createDto.Password);
            
            if(resultadoIdentity.Result.Succeeded) 
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                _emailService.EnviarEmail(new [] { usuarioIdentity.Email }, "Link de ativação", usuarioIdentity.Id, code);
                
                return Result.Ok().WithSuccess(code).WithSuccess(code);
            }

            
            return Result.Fail("Houve uma falha no cadastro");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.Where(usuario => usuario.Id == request.UserId).First();
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoAtivacao).Result;

            if(identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuario");
        }
    }
}