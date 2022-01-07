## Lib to help send mail and help create a smtp client

example
```csharp
 MailMessageCreator.From("********@****.**")
                              .To()
                              .WithCopy()
                              .WithBlindCopy()
                              .ConfigMessage()
                              .Use(Encoding.UTF8)
                              .AddAttachment()
                              .AddAlternateView()
                              .SetSubject("subject")
                              .SetBody("body")
                              .SetAsComplete();
```
```csharp 
var creator = SmtpClientCreator.Configure().ClientConfig(SmtpEnum.Gmail, new SmtpClientConfig()
            {
                Credential = new NetworkCredential("*******@*************", "*******"),
                EnableSsl = true
            });

```
