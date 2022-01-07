namespace Libs.Fluent.Net.Mail.MailMessageCreators.Interfaces
{
    public interface IMailDestinations
    {
        IMailDestinations To(params string[] to);
        IMailDestinations WithCopy(params string[] copias);
        IMailDestinations WithBlindCopy(params string[] copias);
        IMailBaseMessageConfig ConfigMessage();
    }
}
