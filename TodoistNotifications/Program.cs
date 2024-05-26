namespace Program
{
    public class Program
    {
        public static async Task MainAsync()
        {
            var result = Helpers.Json.DeserializeJson<Models.Task[]>(await Services.ApiCalls.GetActiveTasks());
            Console.WriteLine(Helpers.Json.ReturnFirstOfDeserializedObject(result).Due?.Date);
        }
        public static void Main()
        {
            MainAsync().Wait();
        }
    }
}

