using Newtonsoft.Json;

namespace Helpers
{
    public class Json
    {
        public static T DeserializeJson<T>(string inputJsonString)
        {
            var deserialized = JsonConvert.DeserializeObject<T>(inputJsonString);
            return deserialized!;
        }

        public static Models.Task ReturnFirstOfDeserializedObject(Models.Task[] deserializedJson)
        {
            return deserializedJson.First();
        }
    }
}