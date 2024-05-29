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
                else if (task.Due is null)
                {
                    continue;
                }
                else if (task.Due.DateTime is null)
                {
                    continue;
                }
                else
                {
                    DateTime dueDate = Helpers.Time.ConvertDateStringToDateTime(task.Due?.DateTime);                    
                    bool dueSoon = Helpers.Time.EvaluateDueDate(dueDate);
                    if (dueSoon)
                    {
                        Console.WriteLine(task.Content + " -- " + task.Due.DateTime);
                        list += task.Content.ToString() + "\n";
                    }
                    else
                    {
                        continue;
                    } 
                }
            }
            if (list.Length > 0)
            {
                // await Services.SendGrid.SendEmail("This is a test", list, "");
            }
            else
            {
                Console.WriteLine("No tasks due.");
            }
        }
        public static void Main()
        {
            MainAsync().Wait();
        }
    }
}