namespace Private
{
    public class Email
    {
        public static string GetEmailSender()
        {
            try
            {
                string emailSender = Environment.GetEnvironmentVariable("EMAIL_ADDRESS")!;
                return emailSender;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not retrieve email sender address.", ex);
            }
        }
        public static string GetEmailRecipient()
        {
            try
            {
                string emailRecipient = Environment.GetEnvironmentVariable("EMAIL_ADDRESS")!;
                return emailRecipient;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not retrieve email recipient address", ex);
            }
        }
    }
}