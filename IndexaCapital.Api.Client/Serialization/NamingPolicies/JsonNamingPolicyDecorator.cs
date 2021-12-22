using System.Text.Json;

namespace IndexaCapital.Api.Client.Serialization.NamingPolicies
{
    public class JsonNamingPolicyDecorator : JsonNamingPolicy
    {
        private readonly JsonNamingPolicy _underlyingNamingPolicy;

        public JsonNamingPolicyDecorator(JsonNamingPolicy underlyingNamingPolicy) => _underlyingNamingPolicy = underlyingNamingPolicy;

        public override string ConvertName(string name) => _underlyingNamingPolicy == null ? name : _underlyingNamingPolicy.ConvertName(name);
    }
}
