namespace Private
{
    public class Email
    {
        public static string GetEmailSender()
        {
            string emailSender = Environment.GetEnvironmentVariable("EMAIL_ADDRESS")!;
            return emailSender;
        }
        public static string GetEmailRecipient()
        {
            string emailRecipient = Environment.GetEnvironmentVariable("EMAIL_ADDRESS")!;
            return emailRecipient;
        }
    }
}