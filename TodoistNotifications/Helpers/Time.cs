namespace Helpers
{
    public class Time
    {
        public static DateTime ConvertDateStringToDateTime(string date)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(date);
                return dateTime;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not parse date string.", ex);
            }
        }

        public static bool EvaluateDueDate(DateTime date, int hoursUntilDue)
        {
            try
            {
                return date.Subtract(DateTime.Now) <= TimeSpan.FromHours(hoursUntilDue);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not evaluate due date.", ex);
            }
        }
    }
}