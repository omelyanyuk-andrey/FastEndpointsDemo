using API;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DemoDbContext>(options => options.UseInMemoryDatabase("DemoDb"));
builder.Services.AddFastEndpoints();

var app = builder.Build();

app.UseFastEndpoints();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DemoDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
