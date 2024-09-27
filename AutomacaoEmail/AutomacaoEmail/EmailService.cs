using MailKit.Net.Smtp;
using MimeKit;

public class EmailService
{
    private readonly string _smtpServer;
    private readonly int _port;
    private readonly string _username;
    private readonly string _password;

    public EmailService(string smtpServer, int port, string username, string password)
    {
        _smtpServer = smtpServer;
        _port = port;
        _username = username;
        _password = password;
    }

    public void SendEmail(string toEmail, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_username, _username));
        message.To.Add(new MailboxAddress(toEmail, toEmail));
        message.Subject = subject;

        message.Body = new TextPart("html") { Text = body };

        using (var client = new SmtpClient())
        {
            client.Connect(_smtpServer, _port, MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate(_username, _password);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
