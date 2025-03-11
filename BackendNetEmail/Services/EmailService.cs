using BackendNetEmail.Configurations;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using BackendNetEmail.Helpers;
using BackendNetEmail.Interfaces;

namespace BackendNetEmail.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        /// <summary>
        /// Envía un correo electrónico a una lista de destinatarios con la opción de adjuntar archivos.
        /// </summary>
        /// <param name="subject">Asunto del correo electrónico.</param>
        /// <param name="body">Cuerpo del mensaje en formato HTML.</param>
        /// <param name="listDestinations">Lista de direcciones de correo electrónico de los destinatarios.</param>
        /// <param name="attachments">Lista opcional de archivos adjuntos.</param>
        /// <returns>Un mensaje indicando el resultado del envío del correo.</returns>
        public string SendEmail(string subject, string body, List<string> listDestinations, List<Attachment>? attachments)
        {

            try
            {
                MailMessage mailMessage = new()
                {
                    From = new MailAddress(_settings.Email, _settings.DisplayName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                // Agregar destinatarios válidos
                foreach (var item in listDestinations)
                {
                    if (EmailHelper.IsFormatEmail(item))
                        mailMessage.To.Add(item);
                }

                // Agregar adjuntos si existen
                if (attachments != null)
                {
                    foreach (var item in attachments)
                    {
                        mailMessage.Attachments.Add(item);
                    }
                }

                using SmtpClient smtpClient = new(_settings.Host);
                smtpClient.EnableSsl = _settings.EnableSsl;
                smtpClient.UseDefaultCredentials = _settings.UseDefaultCredentials;
                smtpClient.Port = _settings.Port;
                smtpClient.Credentials = new NetworkCredential(_settings.Email, _settings.Password);
                smtpClient.Send(mailMessage);

                return "Correo enviado exitosamente";
            }
            catch (SmtpException smtpEx)
            {
                return $"Error de SMTP: {smtpEx.Message}";
            }
            catch (Exception ex)
            {
                return $"Error inesperado: {ex.Message}";
            }
        }
    }
}
