using Newtonsoft.Json;

namespace HotelManagementAPI.Common
{
    public static class JsonUtils
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        public static string ToJson(this object obj) => Newtonsoft.Json.JsonConvert.SerializeObject(obj, settings);

        public static string FormatJson(this string json)
        {
            try
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(json)!;
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            }
            catch (JsonReaderException)
            {
                // If the JSON is not valid, return the original string
                return json;
            }
            catch (ArgumentNullException)
            {
                return "null";
            }
        }
    }
}
