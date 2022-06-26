using Benkyoukai.Api.Filters;
using Benkyoukai.Api.Middleware;
using Benkyoukai.Application;
using Benkyoukai.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    // builder.Services.AddControllers(opts => opts.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
