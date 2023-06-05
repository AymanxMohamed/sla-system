using Microsoft.EntityFrameworkCore;
using SlaSystem.Infrastructure.Persistence;
using SlaSystem.Presentation.Api;
using SlaSystem.Presentation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    app.UseCors("CorsPolicy");
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

TempApplicationDbContextSeed.Seed();

// #region Database Seed Disabled
// using var scope = app.Services.CreateScope();
// var services = scope.ServiceProvider;
// var context = services.GetRequiredService<ApplicationDbContext>();
// var logger = services.GetRequiredService<ILogger<Program>>();
// try
// {
//     await context.Database.MigrateAsync();
//     await ApplicationDbContextSeed.SeedAsync(context);
// }
// catch (Exception ex)
// {
//     logger.LogError(ex, "An error occured during migration");
// }
//
// #endregion

app.Run();
