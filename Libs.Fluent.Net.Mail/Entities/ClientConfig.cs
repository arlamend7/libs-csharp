using System.Net;
using System.Text;

namespace Libs.Fluent.Net.Mail.Entities
{
    public class SmtpClientConfig
    {
        public NetworkCredential Credential { get; set; }
        public bool EnableSsl { get; set; }
    }
}