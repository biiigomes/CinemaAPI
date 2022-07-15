using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioFuncs.Models;

namespace UsuarioFuncs.Services
{
    public class LogoutService
    {
        private SignInManager<CustomIdentityUser> _signinManager;

        public LogoutService(SignInManager<CustomIdentityUser> signinManager)
        {
            _signinManager = signinManager;
        }

        public Result DeslogaUser()
        {
            var resultadoIdentity = _signinManager.SignOutAsync();
            if(resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("logout falhou");
        }
    }
}