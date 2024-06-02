namespace Models
{
    public static class TaskUrgency
    {
        public static readonly int DueNow = 0;
        public static readonly string DueNowTitle = "Due now";

        public static readonly int VeryUrgent = 1;
        public static readonly string VeryUrgentTitle = "Due in next hour";

        public static readonly int Urgent = 8;
        public static readonly string UrgentTitle = "Due in next eight hours";

        public static readonly int LessUrgent = 24;
        public static readonly string LessUrgentTitle = "Due in next 24 hours";
    }
}
