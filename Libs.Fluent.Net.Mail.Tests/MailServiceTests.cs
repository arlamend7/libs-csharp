using FluentAssertions;
using Libs.Fluent.Net.Mail.Entities;
using Libs.Fluent.Net.Mail.Enums;
using Libs.Fluent.Net.Mail.MailMessageCreators;
using Libs.Fluent.Net.Mail.SmtpClientCreators;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace Libs.Fluent.Net.Mail.Tests
{
    public class MailServiceTests
    {
        [Fact]
        public void CreateSmtpClient()
        {
            var creator = SmtpClientCreator.Configure().ClientConfig(SmtpEnum.Gmail, new SmtpClientConfig()
            {
                Credential = new NetworkCredential("*******@*************", "*******"),
                EnableSsl = true
            });

            creator.Client.Should().BeOfType<SmtpClient>();

            Action<MailMessage> send = creator.Send;
            send.Should().BeOfType<Action<MailMessage>>();
            send = creator.Client.Send;
            send.Should().BeOfType<Action<MailMessage>>();
        }

        [Fact]
        public void CreateMailMessage()
        {
            var mailMessage =
            MailMessageCreator.From("arlanmendes197@gmail.com")
                              .To()
                              .WithCopy()
                              .WithBlindCopy()
                              .ConfigMessage()
                              .Use(Encoding.UTF8)
                              .AddAttachment()
                              .AddAlternateView()
                              .SetSubject("Coe coe")
                              .SetBody("coe")
                              .SetAsComplete();

            mailMessage.Should().BeOfType<MailMessage>();
            mailMessage.From.Should().Be("arlanmendes197@gmail.com");
        }

    }
}
