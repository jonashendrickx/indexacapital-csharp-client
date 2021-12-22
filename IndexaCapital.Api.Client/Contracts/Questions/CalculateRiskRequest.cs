using System.Text.Json.Serialization;

namespace IndexaCapital.Api.Client.Contracts.Questions
{
    public sealed record CalculateRiskRequest
    {
        [JsonPropertyName("goal")]
        public GoalType Goal { get; init; }

        [JsonPropertyName("attitude")]
        public AttitudeType Attitude { get; init; }

        [JsonPropertyName("risk")]
        public RiskType Risk { get; init; }

        [JsonPropertyName("experience")]
        public ExperienceType Experience { get; init; }

        [JsonPropertyName("age")]
        public int Age { get; init; }

        [JsonPropertyName("wealth")]
        public decimal Wealth { get; init; }

        [JsonPropertyName("income")]
        public decimal Income { get; init; }

        [JsonPropertyName("stability")]
        public StabilityType Stability { get; init; }

        [JsonPropertyName("expenses")]
        public ExpensesType Expenses { get; init; }

        [JsonPropertyName("horizon")]
        public HorizonType Horizon { get; init; }
    }
}
