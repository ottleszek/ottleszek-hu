using MailKit.Net.Smtp;
using MimeKit;
using System.Net;

try
{
    // https://www.gmass.co/smtp-test
    using var email = new MimeMessage();
    email.From.Add(new MailboxAddress("Sender name", "from@example.com"));
    email.To.Add(new MailboxAddress("Gyuris Csaba", "gycsaba72@gmail.com"));

    email.Subject = "próba";

    var builder = new BodyBuilder()
    {
        TextBody = "Szöveg"
    };

    email.Body=builder.ToMessageBody();

    using var smtp = new SmtpClient();
    Console.WriteLine(smtp);
    smtp.Connect(host: "sandbox.smtp.mailtrap.io", port: 587,useSsl:false);
    smtp.Authenticate("993bd8fcb037f9", "8e3d7fb1e7bdbd");
    await smtp.SendAsync(email);
    smtp.Disconnect(true);
    Console.WriteLine("Done");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}