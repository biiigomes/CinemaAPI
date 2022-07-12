using FilmesAPI.Models;

namespace CinemaAPI.Data.Dtos.Sessao
{
    public class ReadSessaoDTO
    {
        public int Id { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioEncerramento { get; set; }
        // public DateTime HorarioInicio { get; set; }
    }
}