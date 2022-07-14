using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioFuncs.Data.DTO;
using UsuarioFuncs.Data.Request;
using UsuarioFuncs.Services;

namespace UsuarioFuncs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDTO createDto)
        {
            Result resultado = _cadastroService.CadastraUsuario(createDto);
            if(resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes.First());
        }

        [HttpGet("/ativa")]
        public IActionResult AtivaContaUsuario([FromQuery]AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivaContaUsuario(request);
            if(resultado.IsFailed) return StatusCode(500);
            return Ok(resultado.Successes);
        }
    }
}