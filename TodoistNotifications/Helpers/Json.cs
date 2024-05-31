using Newtonsoft.Json;

namespace Helpers
{
    public class Json
    {
        public static T DeserializeJson<T>(string inputJsonString)
        {
            try
            {
                var deserialized = JsonConvert.DeserializeObject<T>(inputJsonString);
                return deserialized!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Could not deserialize JSON.", ex);
            }
        }
    }
}