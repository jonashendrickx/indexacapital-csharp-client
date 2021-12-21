using IndexaCapital.Api.Client.Serialization.Converters;
using System.Text.Json;

namespace IndexaCapital.Api.Client.Serialization
{
    public sealed class JsonSerializer
    {
        private readonly JsonSerializerOptions _options;
        public JsonSerializer()
        {
            _options = new JsonSerializerOptions
            {
                Converters = { new CustomJsonStringEnumConverter() },
                WriteIndented = true,
            };
        }

        public string Serialize(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj, _options);
        }

        public T? Deserialize<T>(string json)
        {
            if (json == null) return default;
            return System.Text.Json.JsonSerializer.Deserialize<T>(json, _options);
        }
    }
}
