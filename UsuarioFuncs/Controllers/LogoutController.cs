using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioFuncs.Services;

namespace UsuarioFuncs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;
        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUser()
        {
            Result resultado = _logoutService.DeslogaUser();
            if(resultado.IsFailed) return Unauthorized(resultado.Errors.First());
            return Ok(resultado.Successes.First());
        }
    }
}