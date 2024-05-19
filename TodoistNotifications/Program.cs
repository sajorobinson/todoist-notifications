namespace Program
{
    public class Program
    {
        public static async Task MainAsync()
        {
            await Services.ApiCalls.GetActiveTasks();
        }
        public static void Main()
        {
            MainAsync().Wait();
        }
    }
}

