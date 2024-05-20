using Newtonsoft.Json;

namespace Helpers
{
    public class Json
    {
        public static Models.Task[] DeserializeJson(string inputJsonString)
        {
            var deserialized = JsonConvert.DeserializeObject<Models.Task[]>(inputJsonString);
            return deserialized!;
        }

        public static Models.Task ReturnFirstOfDeserializedObject(Models.Task[] deserializedJson)
        {
            return deserializedJson.First();
        }
    }
}