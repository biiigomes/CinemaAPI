using System.ComponentModel.DataAnnotations;

namespace UsuarioFuncs.Data.Request
{
    public class AtivaContaRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string CodigoAtivacao { get; set; }
    }
}