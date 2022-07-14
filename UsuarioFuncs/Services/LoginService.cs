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
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario => 
                    usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser);
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }
        public Result ResetaSenha(EfetuaResetRequest request)
        {
            IdentityUser<int> identityUser =  RecuperaUserPorEmail(request.Email);
            IdentityResult resultadoIdentity = _signInManager.UserManager
                .ResetPasswordAsync(identityUser, request.Token, request.Password)
                .Result;
            if(resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida");
            return Result.Fail("Houve um erro");
        }
        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperaUserPorEmail(request.Email);

            if (identityUser != null)
            {
                string codigoRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync
                    (identityUser).Result;
                return Result.Ok().WithSuccess(codigoRecuperacao);
            }
            return Result.Fail("Falha ao solicitar redefinição");
        }

        private IdentityUser<int>RecuperaUserPorEmail(string email)
        {
            return _signInManager.UserManager.Users.First(u => u.NormalizedEmail == email);
        }
    }
}