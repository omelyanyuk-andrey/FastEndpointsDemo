namespace API.Endpoints.Articles.Requests;

public class UpsertArticleResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public long Rating { get; set; }
}
