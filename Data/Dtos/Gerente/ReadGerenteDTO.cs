using FilmesAPI.Models;

namespace CinemaAPI.Data.Dtos.Gerente
{
    public class ReadGerenteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual object Cinemas { get; set; }
    }
}