using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioFuncs.Data.Request;
using UsuarioFuncs.Services;

namespace UsuarioFuncs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUser(LoginRequest request)
        {
           Result resultado = _loginService.LogaUser(request); 
           if (resultado.IsFailed) return Unauthorized(resultado.Errors.First()); 
           return Ok(resultado.Successes.First());
        }

        [HttpPost("/solicita-reset")]
        public IActionResult SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaResetSenhaUsuario(request);
            if(resultado.IsFailed) return Unauthorized(resultado.Errors.First());
            return Ok(resultado.Successes.First());
        }

        [HttpPost("/efetua-reset")]
        public IActionResult ResetaSenha(EfetuaResetRequest request)
        {
            Result resultado = _loginService.ResetaSenha(request);
            if(resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes.First()); 
        }
    }
}