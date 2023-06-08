using AniListNet.Helpers;
using AniListNet.Objects;

namespace AniListNet.Parameters;

public class MediaReviewMutation
{
    /// <summary>
    /// The review id, required for updating.
    /// </summary>
    public int? Id { get; set; }
    /// <summary>
    /// The id of the media the review is of.
    /// </summary>
    public int MediaId { get; set; }
    /// <summary>
    /// The main review text. Min:2200 characters.
    /// </summary>
    public string? Body { get; set; }
    /// <summary>
    /// A short summary/preview of the review. Min:20, Max:120 characters
    /// </summary>
    public string? Summary { get; set; }
    public int? Score { get; set; }
    /// <summary>
    /// If the review should only be visible to its creator
    /// </summary>
    public bool IsPrivate { get; set; }

    public MediaReviewMutation(MediaReview? mediaReview = null)
    {
        if (mediaReview == null)
            return;
        MediaId = mediaReview.Media.Id;
        Body = mediaReview.Body;
        Summary = mediaReview.Summary;
        Score = mediaReview.Score;
        IsPrivate = mediaReview.IsPrivate;
    }

    internal IEnumerable<GqlParameter> ToParameters()
    {
        var parameters = new List<GqlParameter>();
        parameters.Add(new GqlParameter("private", IsPrivate));
        if (Id.HasValue)
            parameters.Add(new GqlParameter("id", Id));
        if (Score.HasValue)
            parameters.Add(new GqlParameter("score", Score.Value));
        if (!string.IsNullOrEmpty(Summary))
            parameters.Add(new GqlParameter("summary", Summary));
        if (!string.IsNullOrEmpty(Body))
            parameters.Add(new GqlParameter("body", Body));
        return parameters;
    }
}