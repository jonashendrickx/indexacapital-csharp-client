using System.Net;

namespace IndexaCapital.Api.Client.Contracts
{
    public sealed record ContentResponse<T> : BaseResponse
    {


        public ContentResponse(T result, HttpStatusCode httpStatusCode) : base(httpStatusCode)
        {
            Result = result ?? throw new ArgumentNullException(nameof(result));
        }

        public ContentResponse(string errorMessage, HttpStatusCode httpStatusCode) : base(errorMessage, httpStatusCode)
        {
        }

        public T Result { get; private init; } = default!;

        public static ContentResponse<T> Success(T result, HttpStatusCode httpStatusCode)
        {
            return new ContentResponse<T>(result, httpStatusCode);
        }

        public static ContentResponse<T> Fail(string errorMessage, HttpStatusCode httpStatusCode)
        {
            return new ContentResponse<T>(errorMessage, httpStatusCode);
        }
    }
}
