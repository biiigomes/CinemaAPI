using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuarioFuncs.Services
{
    public class LogoutService
    {
        private SignInManager<IdentityUser<int>> _signinManager;

        public LogoutService(SignInManager<IdentityUser<int>> signinManager)
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