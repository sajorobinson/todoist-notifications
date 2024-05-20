namespace Program
{
    public class Program
    {
        public static async Task MainAsync()
        {
            var result = Helpers.Json.DeserializeJson(await Services.ApiCalls.GetActiveTasks());
            Console.WriteLine(Helpers.Json.ReturnFirstOfDeserializedObject(result).Id);
        }
        public static void Main()
        {
            MainAsync().Wait();
        }
    }
}

