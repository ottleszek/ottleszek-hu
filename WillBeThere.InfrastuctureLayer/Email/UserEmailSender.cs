using Microsoft.AspNetCore.Identity;
using Shared.InfrastuctureLayer.Modules.Authentication.Models;

namespace WillBeThere.InfrastuctureLayer.Email
{
    public class UserEmailSender : IEmailSender<User>
    {
        public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
        {
            throw new NotImplementedException();
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
