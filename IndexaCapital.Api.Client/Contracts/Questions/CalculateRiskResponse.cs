using System.Text.Json.Serialization;

namespace IndexaCapital.Api.Client.Contracts.Questions
{
    public sealed record CalculateRiskResponse
    {
        [JsonPropertyName("tolerance")]
        public byte Tolerance { get; init; }

        [JsonPropertyName("capacity")]
        public byte Capacity { get; init; }

        [JsonPropertyName("total")]
        public byte Total { get; init; }
    }
}
