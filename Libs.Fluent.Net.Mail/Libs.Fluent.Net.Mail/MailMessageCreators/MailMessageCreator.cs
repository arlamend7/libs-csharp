using Libs.Fluent.Net.Mail.Entities;
using Libs.Fluent.Net.Mail.MailMessageCreators.Interfaces;
using Libs.System.Extensions;
using System.Net.Mail;
using System.Text;

namespace Libs.Fluent.Net.Mail.MailMessageCreators
{
    public class MailMessageCreator : IMailBaseMessageConfig, IMailDestinations, IMailTo, IMailMessageConfig
    {
        public MailMessage Message { get; private set; }
        private MailMessageCreator()
        {
            Message = new MailMessage();
        }
        public IMailDestinations To(params string[] to)
        {
            foreach (string address in to)
                Message.To.Add(address);
            return this;
        }

        public IMailDestinations WithCopy(params string[] copys)
        {
            foreach (string address in copys)
                Message.CC.Add(address);

            return this;
        }
        public IMailDestinations WithBlindCopy(params string[] copys)
        {
            foreach (string address in copys)
                Message.Bcc.Add(address);

            return this;
        }
        public IMailMessageConfig Use(Encoding encoding, DeliveryNotificationOptions options = DeliveryNotificationOptions.OnSuccess, MailPriority priority = MailPriority.High)
        {
            
            Message.BodyEncoding = Message.HeadersEncoding = Message.SubjectEncoding = encoding;
            Message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            Message.Priority = MailPriority.High;
            return this;
        }

        public IMailMessageConfig UseAsBase(MailMessage baseMessage)
        {
            Message = baseMessage;
            return this;
        }


        public IMailMessageConfig AddAttachment(params MailAttachment[] attachments)
        {
            foreach (MailAttachment attachment in attachments)
                Message.Attachments.Add(new Attachment(attachment.Stream, attachment.Name, attachment.ContentType.GetDescription()));
            return this;
        }
        public IMailMessageConfig SetSubject(string subject)
        {
            Message.Subject = subject;
            return this;
        }

        public IMailMessageConfig SetBody(string body, bool isHtmlBody = false)
        {
            Message.Body = body;
            Message.IsBodyHtml = isHtmlBody;
            return this;
        }

        public IMailMessageConfig AddAlternateView(params AlternateView[] views)
        {
            foreach (var view in views)
                Message.AlternateViews.Add(view);
            return this;
        }

        public MailMessage SetAsComplete()
        {
            return Message;
        }

        public IMailBaseMessageConfig ConfigMessage()
        {
            return this;
        }

        public static IMailDestinations From(string address)
        {
            var creator = new MailMessageCreator();
            creator.Message.From = new MailAddress(address);
            return creator;
        }
    }
}
