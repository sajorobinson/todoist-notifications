using System.Text;

namespace TodoistNotifications.Models
{
    public class TaskList
    {
        public string? Title { get; set; }
        public StringBuilder? Items { get; set; }
    }
}