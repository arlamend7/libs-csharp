using System.Net.Mail;
using System.Text;

namespace Libs.Fluent.Net.Mail.MailMessageCreators.Interfaces
{
    public interface IMailBaseMessageConfig
    {
        IMailMessageConfig Use(Encoding encoding,
                                                DeliveryNotificationOptions options = DeliveryNotificationOptions.OnSuccess,
                                                MailPriority priority = MailPriority.High);
        IMailMessageConfig UseAsBase(MailMessage baseMessage);
    }
}
