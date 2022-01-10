namespace Libs.Fluent.Net.Mail.MailMessageCreators.Interfaces
{
    public interface IMailTo
    {
        IMailDestinations To(params string[] para);
    }
}
