using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioFuncs.Data.Request;
using UsuarioFuncs.Models;

namespace UsuarioFuncs.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUser(LoginRequest request)
        {
           var resultadoIdentity = _signInManager.PasswordSignInAsync
                (request.Username, request.Password, false, false);
            if(resultadoIdentity.Result.Succeeded) 
            {
                var identityUser = _signInManager.UserManager.Users.First
                                 (usuario => usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok();
            }
            return Result.Fail("Login falhou");
        }
    }
}