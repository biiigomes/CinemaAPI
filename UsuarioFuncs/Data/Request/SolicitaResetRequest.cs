using System.ComponentModel.DataAnnotations;

namespace UsuarioFuncs.Data.Request
{
    public class SolicitaResetRequest
    {
        [Required]
        public string Email { get; set; }
    }
}