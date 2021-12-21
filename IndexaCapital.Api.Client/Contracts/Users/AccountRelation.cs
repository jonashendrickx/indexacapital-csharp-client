using System.Text.Json.Serialization;

namespace IndexaCapital.Api.Client.Contracts.Users
{
    public record Account
    {
        [JsonPropertyName("account_number")]
        public string AccountNumber { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("@path")]
        public string Path { get; init; }
    }
}
