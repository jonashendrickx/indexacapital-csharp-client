using System.Text.Json.Serialization;

namespace IndexaCapital.Api.Client.Contracts.Users
{
    public sealed record MeResponse
    {
        [JsonPropertyName("username")]
        public string Username { get; init; }

        [JsonPropertyName("email")]
        public string Email { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("surname")]
        public string SurName { get; init; }

        [JsonPropertyName("phone")]
        public string Phone { get; init; }

        [JsonPropertyName("document_type")]
        public DocumentType DocumentType { get; init; }

        [JsonPropertyName("document")]
        public string Document { get; init; }

        [JsonPropertyName("roles")]
        public IEnumerable<string> Roles { get; init; }

        [JsonPropertyName("is_activated")]
        public bool IsActivated { get; init; }

        [JsonPropertyName("phone_activated")]
        public bool PhoneActivated { get; init; }

        [JsonPropertyName("email_activated")]
        public bool EmailActivated { get; init; }

        [JsonPropertyName("source")]
        public string Source { get; init; }

        [JsonPropertyName("affiliate_fee")]
        public decimal AffiliateFee { get; init; }

        [JsonPropertyName("profiles")]
        public IEnumerable<Guid> Profiles { get; init; }

        [JsonPropertyName("accounts_relations")]
        public IEnumerable<AccountRelation> AccountRelations { get; init; }

        [JsonPropertyName("accounts")]
        public IEnumerable<Account> Accounts { get; init; }
    }
}
