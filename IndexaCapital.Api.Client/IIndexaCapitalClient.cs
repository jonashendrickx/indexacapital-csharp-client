using IndexaCapital.Api.Client.Contracts;
using IndexaCapital.Api.Client.Contracts.Questions;
using IndexaCapital.Api.Client.Contracts.Users;

namespace IndexaCapital.Api.Client
{
    public interface IIndexaCapitalClient
    {
        Task<ContentResponse<CalculateRiskResponse>> CalculateRiskAsync(string product, CalculateRiskRequest request);
        Task<ContentResponse<MeResponse>> GetUserDetailsAsync();
    }
}
