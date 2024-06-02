namespace Program
{
    public class Program
    {
        public static async Task MainAsync()
        {
            var result = Helpers.Json.DeserializeJson<Models.Task[]>(await Services.Todoist.GetActiveTasks());

            Models.TaskList dueNowList = new Models.TaskList
            {
                Title = Models.TaskUrgency.DueNowTitle,
                Items = ""
            };

            Models.TaskList veryUrgentList = new Models.TaskList
            {
                Title = Models.TaskUrgency.VeryUrgentTitle,
                Items = ""
            };

            Models.TaskList urgentList = new Models.TaskList
            {
                Title = Models.TaskUrgency.UrgentTitle,
                Items = ""
            };

            Models.TaskList lessUrgentList = new Models.TaskList
            {
                Title = Models.TaskUrgency.LessUrgentTitle,
                Items = ""
            };

            foreach (Models.Task task in result)
            {
                if (task.Content is null | task.Due is null | task.Due?.DateTime is null)
                { 
                    continue;
                }
                else
                {
                    DateTime dueDate = Helpers.Time.ConvertDateStringToDateTime(task.Due?.DateTime!);
                    
                    bool isDueNow = Helpers.Time.EvaluateDueDate(dueDate, Models.TaskUrgency.DueNow);
                    bool isVeryUrgent = Helpers.Time.EvaluateDueDate(dueDate, Models.TaskUrgency.VeryUrgent);
                    bool isUrgent = Helpers.Time.EvaluateDueDate(dueDate, Models.TaskUrgency.Urgent);
                    bool isLessUrgent = Helpers.Time.EvaluateDueDate(dueDate, Models.TaskUrgency.LessUrgent);
                    
                    if (isDueNow)
                    {
                        dueNowList.Items += task.Content!.ToString() + "\n";
                    }
                    else if (isVeryUrgent)
                    {
                        veryUrgentList.Items += task.Content!.ToString() + "\n";
                    }
                    else if (isUrgent)
                    {
                        urgentList.Items += task.Content!.ToString() + "\n";
                    }
                    else if (isLessUrgent)
                    {
                        urgentList.Items += task.Content!.ToString() + "\n";
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            string payload = "";
            if (dueNowList.Items.Length > 0)
            {
                payload += dueNowList.Title + "\n" + dueNowList.Items + "\n";
            }
            if (veryUrgentList.Items.Length > 0)
            {
                payload += veryUrgentList.Title + "\n" + veryUrgentList.Items + "\n";
            }
            if (urgentList.Items.Length > 0)
            {
                payload += urgentList.Title + "\n" + urgentList.Items + "\n";
            }
            if (lessUrgentList.Items.Length > 0)
            {
                payload += lessUrgentList.Title + "\n" + urgentList.Items + "\n";
            }

            await Services.SendGrid.SendEmail("This is a test", payload, "");
        }
        public static void Main()
        {
            MainAsync().Wait();
        }
    }
}