using Microsoft.VisualBasic;

namespace Helpers
{
    public class Time
    {
        public const string DateTimeFormat = "yyyy-MM-dd'T'HH:mm:ss";
        public static DateTime ConvertDateStringToDateTime(string date)
        {
            try
            {
                DateTime dateTime = DateTime.ParseExact(date, DateTimeFormat, null);
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
                DateTime due = date.ToUniversalTime();
                return due.Subtract(DateTime.UtcNow) < TimeSpan.FromHours(hoursUntilDue);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not evaluate due date.", ex);
            }
        }
    }
}