using Microsoft.AspNetCore.Identity;

namespace UsuarioFuncs.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}