using API.Endpoints.Articles.Mappers;
using API.Endpoints.Articles.Requests;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

namespace API.Endpoints.Articles;

public class UpsertArticleEndpoint(DemoDbContext dbContext)
    : Endpoint<UpsertArticleRequest, UpsertArticleResponse, ArticleMapper>
{
    public override void Configure()
    {
        Post("/articles");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpsertArticleRequest request, CancellationToken c)
    {
        if (request.Id is null)
        {
            var createdArticle = await dbContext.AddAsync(Map.ToEntity(request), c);
            await dbContext.SaveChangesAsync(c);
            await SendOkAsync(Map.FromEntity(createdArticle.Entity), c);
        }
        else
        {
            var existingArticle = await dbContext.Articles.FirstOrDefaultAsync(
                a => a.Id == request.Id,
                c
            );
            if (existingArticle is null)
            {
                await SendNotFoundAsync(c);
                return;
            }

            existingArticle.Title = request.Title;
            await dbContext.SaveChangesAsync(c);
            await SendOkAsync(Map.FromEntity(existingArticle), c);
        }
    }
}
