using System.Text.Json.Serialization;

namespace IndexaCapital.Api.Client.Contracts.Users
{
    public record AccountRelation
    {
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; init; }

        [JsonPropertyName("relation")]
        public string Relation { get; init; }
    }
}
