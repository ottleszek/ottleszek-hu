using MailKit.Net.Smtp;
using MimeKit;

try
{
    // https://www.gmass.co/smtp-test
    var newemial = new MimeMessage();
    newemial.From.Add(new MailboxAddress("Sender name", "from@example.com"));
    newemial.To.Add(new MailboxAddress("Gyuris Csaba", "gycsaba72@gmail.com"));

    newemial.Subject = "próba";

    var builder = new BodyBuilder()
    {
        TextBody = "Szöveg"
    };

    newemial.Body=builder.ToMessageBody();

    using var smtp = new SmtpClient();
    Console.WriteLine(smtp);
    //smtp.Connect(host: "sandbox.smtp.mailtrap.io", port: 465,useSsl:false);
    smtp.Connect("sandbox.smtp.mailtrap.io", 465, MailKit.Security.SecureSocketOptions.StartTls);
    smtp.Authenticate("993bd8fcb037f9", "8e3d7fb1e7bdbd");
    await smtp.SendAsync(newemial);
    smtp.Disconnect(true);
    Console.WriteLine("Done");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}