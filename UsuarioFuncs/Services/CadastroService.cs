using System.Web;
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
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService _emailService;
        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager = null)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }
        public Result CadastraUsuario(CreateUsuarioDTO createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto); 
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            Task<IdentityResult> resultadoIdentity = _userManager
                .CreateAsync(usuarioIdentity, createDto.Password);

            _userManager.AddToRoleAsync(usuarioIdentity, "regular");
            if(resultadoIdentity.Result.Succeeded) 
            {              
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new [] { usuarioIdentity.Email }, "Link de ativação", usuarioIdentity.Id, encodedCode);
                
                return Result.Ok().WithSuccess(code).WithSuccess(code);
            }

            
            return Result.Fail("Houve uma falha no cadastro");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            var identityUser = _userManager.Users.First(usuario => usuario.Id == request.UserId);
            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoAtivacao).Result;

            if(identityResult.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar conta de usuario");
        }
    }
}