namespace Program
{
    public class Program
    {
        public static async Task MainAsync()
        {
            var result = Helpers.Json.DeserializeJson<Models.Task[]>(await Services.Todoist.GetActiveTasks());
            foreach (Models.Task task in result)
            {
                Console.WriteLine(task.Content);
            }
            //Console.WriteLine(Helpers.Json.ReturnFirstOfDeserializedObject(result).Due?.Date);
        }
        public static void Main()
        {
            MainAsync().Wait();
        }
    }
}

