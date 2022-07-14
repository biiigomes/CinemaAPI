using MimeKit;

namespace UsuarioFuncs.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public Mensagem(IEnumerable<string> destinatario, string assunto, int userId, string codigo)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress("Bianca Gomes", d)));
            Assunto = assunto;
            Conteudo = $"https://localhost:7098/ativa?UserId={userId}&CodigoAtivacao={codigo}";
        }
    }
}