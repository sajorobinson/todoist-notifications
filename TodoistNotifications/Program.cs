namespace Program
{
    public class Program
    {
        public static async Task MainAsync()
        {
            var result = Helpers.Json.DeserializeJson<Models.Task[]>(await Services.Todoist.GetActiveTasks());
            string list = "";
            foreach (Models.Task task in result)
            {
                if (task.Content is null)
                {
                    continue;
                }
                else
                {
                    list+= task.Content.ToString() + "\n";
                }
            }
            await Services.SendGrid.SendEmail("This is a test", list, "");
        }
        public static void Main()
        {
            MainAsync().Wait();
        }
    }
}