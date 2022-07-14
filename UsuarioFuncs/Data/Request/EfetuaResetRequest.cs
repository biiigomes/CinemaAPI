using System.ComponentModel.DataAnnotations;

namespace UsuarioFuncs.Data.Request
{
    public class EfetuaResetRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Repassword { get; set; }
        [Required]
        public string Token { get; set; }
    }
}