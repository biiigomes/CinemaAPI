
using MailKit.Net.Smtp;
using MimeKit;
using UsuarioFuncs.Models;

namespace UsuarioFuncs.Services
{
    public class EmailService
    {
        public void EnviarEmail(string[] destinatario, string assunto, int userId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, userId, code);
            var mensagemDeEmail = CriaCorpoDoEMail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using(var cliente = new SmtpClient())
            {
                try
                {
                    cliente.Connect("TODO");
                    cliente.Send(mensagemDeEmail);
                }
            };
        }

        private MimeMessage CriaCorpoDoEMail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("ADICIONAR REMETENTE"));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemDeEmail;
        }
    } 
}