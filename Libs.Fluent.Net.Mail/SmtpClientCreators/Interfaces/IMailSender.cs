using System.Net.Mail;

namespace Libs.Fluent.Net.Mail.SmtpClientCreators.Interfaces
{
    public interface IMailSender
    {
        SmtpClient Client { get; }
        void Send(MailMessage mail);
    }
}
