using System.Text.Json;

namespace IndexaCapital.Api.Client.Serialization
{
    public sealed class JsonSerializer
    {
        private readonly JsonSerializerOptions _options;
        public JsonSerializer()
        {
            _options = new JsonSerializerOptions();
        }

        public string Serialize(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj, _options);
        }

        public T? Deserialize<T>(string json)
        {
            return string.IsNullOrEmpty(json) ? default : System.Text.Json.JsonSerializer.Deserialize<T>(json, _options);
        }
    }
}
