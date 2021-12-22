using IndexaCapital.Api.Client.Serialization.NamingPolicies;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IndexaCapital.Api.Client.Serialization.Converters
{
    public class CustomStringToEnumConverter : JsonConverterFactory
    {
        private readonly JsonNamingPolicy _namingPolicy;
        private readonly bool _allowIntegerValues;
        private readonly JsonStringEnumConverter _baseConverter;

        public CustomStringToEnumConverter() : this(null, true) { }

        public CustomStringToEnumConverter(JsonNamingPolicy namingPolicy = null, bool allowIntegerValues = true)
        {
            this._namingPolicy = namingPolicy;
            this._allowIntegerValues = allowIntegerValues;
            this._baseConverter = new JsonStringEnumConverter(namingPolicy, allowIntegerValues);
        }

        public override bool CanConvert(Type typeToConvert) => _baseConverter.CanConvert(typeToConvert);

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
                        let attr = field.GetCustomAttribute<EnumMemberAttribute>()
                        where attr != null
                        select (field.Name, attr.Value);
            var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
            if (dictionary.Count > 0)
            {
                return new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, _namingPolicy), _allowIntegerValues).CreateConverter(typeToConvert, options);
            }
            else
            {
                return _baseConverter.CreateConverter(typeToConvert, options);
            }
        }
    }

}
