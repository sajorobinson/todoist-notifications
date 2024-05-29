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

        public static bool EvaluateDueDate(System.DateTime date)
        {
            try
            {
                return date.Subtract(DateTime.Now) < TimeSpan.FromHours(8);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not evaluate due date.", ex);
            }
            
        }
    }
}