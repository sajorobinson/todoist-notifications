using System.Xml.XPath;

namespace TodoistNotifications.Helpers
{
    public static class Time
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
        public static double EvaluateDueDate(DateTime date)
        {
            try
            {
                DateTime due = date.ToUniversalTime();
                return due.Subtract(DateTime.UtcNow).TotalHours;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not evaluate due date.", ex);
            }
        }
    }
}