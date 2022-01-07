using Libs.Fluent.Net.Mail.Entities;
using System.Net.Mail;

namespace Libs.Fluent.Net.Mail.MailMessageCreators.Interfaces
{
    public interface IMailMessageConfig
    {
        IMailMessageConfig AddAttachment(params MailAttachment[] attachments);
        IMailMessageConfig SetSubject(string subject);
        IMailMessageConfig SetBody(string body, bool isHtmlBody = false);
        IMailMessageConfig AddAlternateView(params AlternateView[] view);
        MailMessage SetAsComplete();
    }
}
