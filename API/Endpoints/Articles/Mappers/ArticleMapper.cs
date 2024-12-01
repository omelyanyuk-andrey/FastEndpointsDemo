using API.Endpoints.Articles.Requests;
using API.Entities;
using FastEndpoints;

namespace API.Endpoints.Articles.Mappers;

public class ArticleMapper : Mapper<UpsertArticleRequest, UpsertArticleResponse, ArticleEntity>
{
    public override ArticleEntity ToEntity(UpsertArticleRequest request)
    {
        return new() { Title = request.Title };
    }

    public override UpsertArticleResponse FromEntity(ArticleEntity entity)
    {
        var random = new Random();
        return new()
        {
            Id = entity.Id,
            Title = entity.Title,
            Rating = random.Next(1, 100),
        };
    }
}
