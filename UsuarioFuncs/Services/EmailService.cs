
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using UsuarioFuncs.Models;

namespace UsuarioFuncs.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
                try{
                    //configuracao para enviar email
                    cliente.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), SecureSocketOptions.StartTls);

                    cliente.AuthenticationMechanisms.Remove("XOUATH2");
                    cliente.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    cliente.Send(mensagemDeEmail);
                } catch {
                    throw;
                } finally {
                    cliente.Disconnect(true);
                    cliente.Dispose();
                }
            };
        }

        private MimeMessage CriaCorpoDoEMail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("biancatestes43@gmail.com", _configuration.GetValue<string>("EmailSettings:From")));
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