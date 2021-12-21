using System.Net;

namespace IndexaCapital.Api.Client.Contracts
{
    public sealed record NoContentResponse : BaseResponse
    {
        public NoContentResponse(HttpStatusCode statusCode) : base(statusCode)
        {

        }

        public NoContentResponse(string errorMessage, HttpStatusCode httpStatusCode) : base(errorMessage, httpStatusCode)
        {
        }

        public static NoContentResponse Success(HttpStatusCode statusCode)
        {
            return new NoContentResponse(statusCode);
        }

        public static NoContentResponse Fail(string errorMessage, HttpStatusCode httpStatusCode)
        {
            return new NoContentResponse(errorMessage, httpStatusCode);
        }
    }
}
