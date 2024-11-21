using Microsoft.AspNetCore.Identity;
using MimeKit;
using MailKit.Net.Smtp;
using Shared.InfrastuctureLayer.Modules.Authentication.Models;


namespace WillBeThere.InfrastuctureLayer.Email
{
    public class UserEmailSender : IEmailSender<User>
    {
        public async Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
        {
            using var newemail = new MimeMessage();
            newemail.From.Add(new MailboxAddress("Regisztráció", "noreplay@ottleszek.hu"));
            newemail.To.Add(new MailboxAddress(user.Email, user.Email));

            var builder = new BodyBuilder();
            builder.HtmlBody = $@"
                    <html>
                        <body>
                            <h2>Kedves {user.Email}!</h2>
                            <p>Köszönjük, hogy regisztráltál! Kérjük, erősítsd meg a regisztrációdat a következő linkre kattintva:</p>
                            <p><a href='{confirmationLink}'>Regisztráció megerősítése</a></p>
                            <p>Üdvözlettel,<br>Az Ottleszek.hu csapata</p>
                        </body>
                    </html>";

            builder.TextBody = $"Kedves {user.Email}!\n\nKérjük, erősítsd meg a regisztrációdat az alábbi linkre kattintva:\n{confirmationLink}\n\nÜdvözlettel,\nAz Ottleszek.hu csapata";

            newemail.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            Console.WriteLine(smtp);
            //smtp.Connect(host: "sandbox.smtp.mailtrap.io", port: 465,useSsl:false);
            smtp.Connect("sandbox.smtp.mailtrap.io", 465, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("993bd8fcb037f9", "8e3d7fb1e7bdbd");
            await smtp.SendAsync(newemail);
            smtp.Disconnect(true);

        }

        public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
        {
            throw new NotImplementedException();
        }

        public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
        {
            throw new NotImplementedException();
        }
    }
}
