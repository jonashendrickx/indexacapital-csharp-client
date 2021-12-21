using System.Net;
using System.Text.Json.Serialization;

namespace IndexaCapital.Api.Client.Contracts.Error
{
    public record ErrorResponse
    {
        [JsonPropertyName("code")]
        public HttpStatusCode HttpStatusCode { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }
    }
}
