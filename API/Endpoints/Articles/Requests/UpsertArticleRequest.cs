using System.Data;
using FastEndpoints;
using FluentValidation;

namespace API.Endpoints.Articles.Requests;

public class UpsertArticleRequest
{
    public long? Id { get; set; }
    public string Title { get; set; }
}

public class RequestValidator : Validator<UpsertArticleRequest>
{
    public RequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required")
            .MinimumLength(5)
            .WithMessage("Minimal length is 5");
    }
}
