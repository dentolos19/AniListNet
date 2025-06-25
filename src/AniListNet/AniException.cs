using System.Net;

namespace AniListNet;

public class AniException : Exception
{
    public string ActualRequestBody { get; }
    public string ActualResponseBody { get; }
    
    public HttpStatusCode StatusCode { get; }

    internal AniException(string message, string actualRequestBody, string actualResponseBody, HttpStatusCode statusCode) : base(message)
    {
        ActualRequestBody = actualRequestBody;
        ActualResponseBody = actualResponseBody;
        StatusCode = statusCode;
    }
}