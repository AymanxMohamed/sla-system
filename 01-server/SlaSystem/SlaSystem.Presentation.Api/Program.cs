using SlaSystem.Presentation.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();


var app = builder.Build();

// Configure the HTTP request pipeline.
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
