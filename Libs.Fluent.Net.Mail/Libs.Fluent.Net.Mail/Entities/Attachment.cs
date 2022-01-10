using Libs.Fluent.Net.Mail.Enums;
using System.IO;

namespace Libs.Fluent.Net.Mail.Entities
{
    public class MailAttachment
    {
        public Stream Stream { get; set; }
        public string Name { get; set; }
        public ContentTypeEnum ContentType { get; set; }

        public MailAttachment(Stream stream, string name, ContentTypeEnum contentType)
        {
            Stream = stream;
            Name = name;
            ContentType = contentType;
        }
    }
}