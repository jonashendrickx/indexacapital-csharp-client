using IndexaCapital.Api.Client.Contracts;
using IndexaCapital.Api.Client.Contracts.Error;
using IndexaCapital.Api.Client.Contracts.Questions;
using IndexaCapital.Api.Client.Contracts.Users;
using IndexaCapital.Api.Client.ContractValidators.Questions;
using IndexaCapital.Api.Client.Serialization;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace IndexaCapital.Api.Client
{
    public class IndexaCapitalClient : IIndexaCapitalClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializer _serializer;

        private IndexaCapitalClient()
        {
            _serializer = new JsonSerializer();
        }

        public IndexaCapitalClient(string token) : this()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", token);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        /// <summary>
        /// Only used for unit testing purposes.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public IndexaCapitalClient(HttpClient httpClient) : this()
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);
        }

        public async Task<ContentResponse<CalculateRiskResponse>> CalculateRiskAsync(string product, CalculateRiskRequest request)
        {
            var validationResult = new CalculateRiskRequestValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.ToString(), nameof(request));
            }

            var requestJson = _serializer.Serialize(request);
            var content = new StringContent(requestJson, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await _httpClient.PostAsync($"https://api.indexacapital.com/questions/{product}/calculate-risk", content);
            var json = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = _serializer.Deserialize<CalculateRiskResponse>(json);
                return ContentResponse<CalculateRiskResponse>.Success(result, response.StatusCode);
            }
            else
            {
                var result = _serializer.Deserialize<ErrorResponse>(json);
                return ContentResponse<CalculateRiskResponse>.Fail(result.Message, result.HttpStatusCode);
            }
        }

        public async Task<ContentResponse<MeResponse>> GetUserDetailsAsync()
        {
            var response = await _httpClient.GetAsync("https://api.indexacapital.com/users/me");
            var json = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = _serializer.Deserialize<MeResponse>(json);
                return ContentResponse<MeResponse>.Success(result, response.StatusCode);
            }
            else
            {
                var result = _serializer.Deserialize<ErrorResponse>(json);
                return ContentResponse<MeResponse>.Fail(result.Message, result.HttpStatusCode);
            }
        }
    }
}