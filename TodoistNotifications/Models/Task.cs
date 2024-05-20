using System.Text.Json.Serialization;

namespace Models
{
    public class Task
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("assigner_id")]
        public string? AssignerId { get; set; }

        [JsonPropertyName("assignee_id")]
        public string? AssigneeId { get; set; }

        [JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        [JsonPropertyName("section_id")]
        public string? SectionId { get; set; }

        [JsonPropertyName("parent_id")]
        public string? ParentId { get; set; }

        [JsonPropertyName("order")]
        public int? Order { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("is_completed")]
        public bool? IsCompleted { get; set; }

        [JsonPropertyName("labels")]
        public List<string>? Labels { get; set; }

        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        [JsonPropertyName("comment_count")]
        public int? CommentCount { get; set; }

        [JsonPropertyName("creator_id")]
        public string? CreatorId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("due")]
        public TaskDue? Due { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("duration")]
        public TimeSpan? Duration { get; set; }
    }

    public class TaskDue
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("string")]
        public string? RecurrenceString { get; set; } // Renamed for clarity

        [JsonPropertyName("lang")]
        public string? Language { get; set; }

        [JsonPropertyName("is_recurring")]
        public bool IsRecurring { get; set; }
    }
}