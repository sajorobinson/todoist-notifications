namespace Private
{
    public class Credentials
    {
        public static string TodoistApiToken()
        {
            string token = Environment.GetEnvironmentVariable("TODOIST_API_TOKEN")!;
            return token;
        }
        public static string SendGridApiToken()
        {
            string token = Environment.GetEnvironmentVariable("SENDGRID_API_TOKEN")!;
            return token;
        }
    }
}