namespace Helpers
{
    public class Time
    {
        public static DateTime ConvertDateStringToDateTime(string date)
        {
            DateTime dateTime = DateTime.Parse(date);
            return dateTime;
        }

        public static bool EvaluateDueDate(System.DateTime date)
        {
            return date.Subtract(DateTime.Now) < TimeSpan.FromHours(8);
        }
    }
}