using Libs.Fluent.Net.Mail.MailMessageCreators.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Mail;

namespace Libs.Fluent.Net.Mail.AspNetCore
{
    public static class MailMessageCreatorsExtensions
    {
        public static IMailMessageConfig AddAnexos(this IMailMessageConfig config, IFormFileCollection anexos)
        {
            if (anexos.Any())
                foreach (IFormFile item in anexos)
                    config.Message.Attachments.Add(new Attachment(item.OpenReadStream(), item.FileName));

            return config;
        }
    }
}
