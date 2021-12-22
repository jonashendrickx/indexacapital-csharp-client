using System.Text.Json;

namespace IndexaCapital.Api.Client.Serialization.NamingPolicies
{
    public sealed class DictionaryLookupNamingPolicy : JsonNamingPolicyDecorator
    {
        private readonly Dictionary<string, string> _dictionary;

        public DictionaryLookupNamingPolicy(Dictionary<string, string> dictionary, JsonNamingPolicy underlyingNamingPolicy) : base(underlyingNamingPolicy) => _dictionary = dictionary ?? throw new ArgumentNullException();

        public override string ConvertName(string name) => _dictionary.TryGetValue(name, out var value) ? value : base.ConvertName("name");
    }
}
