using IndexaCapital.Api.Client.Contracts;
using IndexaCapital.Api.Client.Contracts.Error;
using IndexaCapital.Api.Client.Contracts.Users;
using IndexaCapital.Api.Client.Serialization;

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
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
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
                return ContentResponse<MeResponse>.Fail(result.Message, response.StatusCode);
            }
        }
    }
}