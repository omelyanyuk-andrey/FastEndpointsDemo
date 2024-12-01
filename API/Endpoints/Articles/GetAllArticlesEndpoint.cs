using API.Entities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace API.Endpoints.Articles;

public class GetAllArticlesEndpoint(DemoDbContext demoDbContext)
    : EndpointWithoutRequest<ICollection<ArticleEntity>>
{
    public override void Configure()
    {
        Get("/articles");
        AllowAnonymous();
    }

    /*public override async Task<ICollection<ArticleEntity>> ExecuteAsync(CancellationToken ct)
    {
        var articles = await demoDbContext.Articles.ToListAsync(ct);
        return articles;
    }*/

    public override async Task HandleAsync(CancellationToken ct)
    {
        var articles = await demoDbContext.Articles.ToListAsync(ct);
        await SendOkAsync(articles, ct);
    }
}
