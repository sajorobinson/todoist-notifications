// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Services
{
    class SendGrid
    {
        static async Task SendEmail()
        {
            var apiKey = Private.Credentials.SendGridApiToken();
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Private.Email.GetEmailSender(), "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(Private.Email.GetEmailRecipient(), "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}