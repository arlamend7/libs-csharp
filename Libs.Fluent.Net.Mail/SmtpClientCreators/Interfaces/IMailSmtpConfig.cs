using Libs.Fluent.Net.Mail.Entities;
using Libs.Fluent.Net.Mail.Enums;

namespace Libs.Fluent.Net.Mail.SmtpClientCreators.Interfaces
{
    public interface IMailSmtpConfig
    {
        IMailSender ClientConfig(string smtp, int port, string email, string password, bool enableSsl = false);
        IMailSender ClientConfig(SmtpEnum smtp, string email, string password,bool enableSsl = false);
        IMailSender ClientConfig(SmtpEnum smtp, SmtpClientConfig client);
        IMailSender ClientConfig(string smtp, int port, SmtpClientConfig client);
    }
}
