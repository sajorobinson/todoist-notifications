namespace Program
{
    public class Program
    {
        public static async Task MainAsync()
        {
            var result = Helpers.Json.DeserializeJson<Models.Task[]>(await Services.Todoist.GetActiveTasks());

            Models.TaskList listDueNow = new Models.TaskList();
            listDueNow.Title = "Due now:\n";
            listDueNow.Items = "";

            Models.TaskList listVeryUrgent = new Models.TaskList();
            listVeryUrgent.Title = "Very urgent:\n";
            listVeryUrgent.Items = "";

            Models.TaskList listUrgent = new Models.TaskList();
            listUrgent.Title = "Urgent: \n";
            listUrgent.Items = "";

            Models.TaskList listLessUrgent = new Models.TaskList();
            listLessUrgent.Title = "Less urgent:\n";
            listLessUrgent.Items = "";

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
                    DateTime dueDate = Helpers.Time.ConvertDateStringToDateTime(task.Due?.DateTime!);
                    
                    bool dueNow = Helpers.Time.EvaluateDueDate(dueDate, Convert.ToInt32(Models.TaskUrgency.DueNow));
                    bool veryUrgent = Helpers.Time.EvaluateDueDate(dueDate, Convert.ToInt32(Models.TaskUrgency.VeryUrgent));
                    bool urgent = Helpers.Time.EvaluateDueDate(dueDate, Convert.ToInt32(Models.TaskUrgency.Urgent));
                    bool lessUrgent = Helpers.Time.EvaluateDueDate(dueDate, Convert.ToInt32(Models.TaskUrgency.LessUrgent));
                    
                    if (dueNow)
                    {
                        listDueNow.Items += task.Content.ToString() + "\n";
                    }
                    else if (veryUrgent)
                    {
                        listVeryUrgent.Items += task.Content.ToString() + "\n";
                    }
                    else if (urgent)
                    {
                        listUrgent.Items += task.Content.ToString() + "\n";
                    }
                    else if (lessUrgent)
                    {
                        listUrgent.Items += task.Content.ToString() + "\n";
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            string payload = "";

            if (listDueNow.Items.Length > 0)
            {
                payload += listDueNow.Title + "\n" + listDueNow.Items + "\n";
            }

            if (listVeryUrgent.Items.Length > 0)
            {
                payload += listVeryUrgent.Title + "\n" + listVeryUrgent.Items + "\n";
            }

            if (listUrgent.Items.Length > 0)
            {
                payload += listUrgent.Title + "\n" + listUrgent.Items + "\n";
            }

            if (listLessUrgent.Items.Length > 0)
            {
                payload += listLessUrgent.Title + "\n" + listUrgent.Items + "\n";
            }

            await Services.SendGrid.SendEmail("This is a test", payload, "");
        }
        public static void Main()
        {
            MainAsync().Wait();
        }
    }
}