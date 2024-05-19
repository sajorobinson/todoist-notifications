namespace Models
{
    public class Task
    {
        public string? Id { get; set; }
        public string? AssignerId { get; set; }
        public string? AssigneeId { get; set; }
        public string? ProjectId { get; set; }
        public string? SectionId { get; set; }
        public string? ParentId { get; set; }
        public int? Order { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public bool? IsCompleted { get; set; }
        public List<string>? Labels { get; set; }
        public int? Priority { get; set; }
        public int? CommentCount { get; set; }
        public string? CreatorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? Due { get; set; }
        public TimeSpan? Duration { get; set; }

    }
}