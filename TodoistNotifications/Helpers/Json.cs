using Newtonsoft.Json;

namespace Helpers
{
    public class Json
    {
        public static object DeserializeJson(string inputJsonString)
        {
            var deserialized = JsonConvert.DeserializeObject(inputJsonString);
            return deserialized!;
        }
    }
}