using System.Text;

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
                Items = new StringBuilder()
            };
            Models.TaskList veryUrgentList = new Models.TaskList
            {
                Title = Models.TaskUrgency.VeryUrgentTitle,
                Items = new StringBuilder()
            };
            Models.TaskList urgentList = new Models.TaskList
            {
                Title = Models.TaskUrgency.UrgentTitle,
                Items = new StringBuilder()
            };
            Models.TaskList lessUrgentList = new Models.TaskList
            {
                Title = Models.TaskUrgency.LessUrgentTitle,
                Items = new StringBuilder()
            };
            foreach (Models.Task task in result)
            {
                if (task.Content is null || task.Due is null || task.Due?.DateTime is null)
                {
                    continue;
                }
                DateTime dueDate = Helpers.Time.ConvertDateStringToDateTime(task.Due.DateTime);
                double dueIn = Helpers.Time.EvaluateDueDate(dueDate);
                string taskContent = task.Content.ToString() + "\n";
                if (dueIn <= Models.TaskUrgency.DueNow)
                {
                    dueNowList.Items.Append(taskContent);
                }
                else if (dueIn <= Models.TaskUrgency.VeryUrgent)
                {
                    veryUrgentList.Items.Append(taskContent);
                }
                else if (dueIn <= Models.TaskUrgency.Urgent)
                {
                    urgentList.Items.Append(taskContent);
                }
                else if (dueIn <= Models.TaskUrgency.LessUrgent)
                {
                    lessUrgentList.Items.Append(taskContent);
                }
                else
                {
                    continue;
                }
            }
            StringBuilder payload = new StringBuilder();
            if (dueNowList.Items.Length > 0)
            {
                payload.Append($"{dueNowList.Title}\n{dueNowList.Items}\n");
            }
            if (veryUrgentList.Items.Length > 0)
            {
                payload.Append($"{veryUrgentList.Title}\n{veryUrgentList.Items}\n");
            }
            if (urgentList.Items.Length > 0)
            {
                payload.Append($"{urgentList.Title}\n{urgentList.Items}\n");
            }
            if (lessUrgentList.Items.Length > 0)
            {
                payload.Append($"{lessUrgentList.Title}\n{lessUrgentList.Items}\n");
            }
            await Services.SendGrid.SendEmail("This is a test", payload.ToString(), "");
        }
        public static void Main()
        {
            MainAsync().Wait();
        }
    }
}