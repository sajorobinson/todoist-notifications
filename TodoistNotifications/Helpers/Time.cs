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

        public static DateTime ConvertToUniversalTime(DateTime dateTime)
        {
            return dateTime.Kind switch
            {
                DateTimeKind.Unspecified => dateTime.ToUniversalTime(),
                DateTimeKind.Local => dateTime.ToUniversalTime(),
                _ => dateTime, // Already in UTC or another Kind
            };
        }

        public static bool EvaluateDueDate(DateTime date, int hoursUntilDue)
        {
            try
            {
                DateTime inputToUtc = ConvertToUniversalTime(date);
                DateTime nowToUtc = ConvertToUniversalTime(DateTime.Now);
                return inputToUtc.Subtract(nowToUtc) < TimeSpan.FromHours(hoursUntilDue);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not evaluate due date.", ex);
            }
        }
    }
}