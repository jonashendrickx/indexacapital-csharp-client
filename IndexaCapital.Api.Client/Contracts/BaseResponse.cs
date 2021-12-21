using System.Net;

namespace IndexaCapital.Api.Client.Contracts
{
    public abstract record BaseResponse
    {
        public BaseResponse(HttpStatusCode httpStatusCode)
        {
            HttpStatusCode = httpStatusCode;
        }

        public BaseResponse(string errorMessage, HttpStatusCode httpStatusCode) : this(httpStatusCode)
        {
            ErrorMessage = errorMessage;
        }

        public HttpStatusCode HttpStatusCode { get; private init; }

        public string ErrorMessage { get; private init; }

        public bool HasErrors => ErrorMessage != null;
    }
}
