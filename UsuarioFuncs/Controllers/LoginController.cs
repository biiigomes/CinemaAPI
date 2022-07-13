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
           if (resultado.IsFailed) return Unauthorized(resultado.Errors.FirstOrDefault()); 
           return Ok(resultado.Successes.FirstOrDefault());
        }
    }
}