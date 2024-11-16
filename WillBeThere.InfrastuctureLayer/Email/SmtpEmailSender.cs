﻿using Microsoft.AspNetCore.Identity.UI.Services;

namespace WillBeThere.InfrastuctureLayer.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Console.WriteLine($"Mock email sent to {email} with subject '{subject}'");
            return Task.CompletedTask;
        }
    }
}
