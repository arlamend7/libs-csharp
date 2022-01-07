using Libs.Fluent.Net.Mail.Entities;
using Libs.Fluent.Net.Mail.Enums;
using Libs.Fluent.Net.Mail.SmtpClientCreators.Interfaces;
using Libs.System.Extensions;
using System.Net;
using System.Net.Mail;

namespace Libs.Fluent.Net.Mail.SmtpClientCreators
{
    public class SmtpClientCreator : IMailSmtpConfig, IMailSender 
    {
        public SmtpClient Client { get; private set; }

        public static IMailSmtpConfig Configure()
        {
            return new SmtpClientCreator();
        }

        public IMailSender ClientConfig(string smtp, int port, string email, string password, bool enableSsl = false)
        {
            return ClientConfig(smtp, port, new SmtpClientConfig()
            {
                Credential = new NetworkCredential(email, password),
                EnableSsl = enableSsl,
            });
        }

        public IMailSender ClientConfig(SmtpEnum smtp, string email, string password, bool enableSsl = false)
        {
            return ClientConfig(smtp.GetDescription(), 587, new SmtpClientConfig()
            {
                Credential = new NetworkCredential(email, password),
                EnableSsl = enableSsl,
            });
        }

        public IMailSender ClientConfig(SmtpEnum smtp, SmtpClientConfig client)
        {
            return ClientConfig(smtp.GetDescription(), 587, client);
        }

        public IMailSender ClientConfig(string smtp, int port, SmtpClientConfig client)
        {
            Client = new SmtpClient(smtp, port)
            {
                Credentials = client.Credential
            };
            Client.EnableSsl = client.EnableSsl;

            return this;
        }

        /// <summary>
        ///     You can create by MailCreator.From("anyone@something.com")
        /// </summary>
        /// <param name="mail"></param>
        public void Send(MailMessage mail)
        {
            Client.Send(mail);
        }
    }
}
