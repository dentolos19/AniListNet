namespace AniListNet;

public class AniException : Exception
{
    public string ActualRequestBody { get; }
    public string ActualResponseBody { get; }

    internal AniException(string message, string actualRequestBody, string actualResponseBody) : base(message)
    {
        ActualRequestBody = actualRequestBody;
        ActualResponseBody = actualResponseBody;
    }
}