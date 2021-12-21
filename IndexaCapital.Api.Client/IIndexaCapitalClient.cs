using IndexaCapital.Api.Client.Contracts;
using IndexaCapital.Api.Client.Contracts.Users;

namespace IndexaCapital.Api.Client
{
    public interface IIndexaCapitalClient
    {
        Task<ContentResponse<MeResponse>> GetUserDetailsAsync();
    }
}
