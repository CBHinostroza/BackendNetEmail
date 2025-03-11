using System.Net.Mail;

namespace BackendNetEmail.Interfaces
{
    public interface IEmailService
    {
        public string SendEmail(string subject, string body, List<string> listDestinations, List<Attachment>? attachments);
    }
}
