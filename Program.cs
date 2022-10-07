using BackendInnovationAPI.DatabaseSettings;
using BackendInnovationAPI.Services.IdeaServices;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Data.Common;
using System.Data;
using BackendInnovationAPI.Services.FeedbackServices;
using BackendInnovationAPI.Services.PortfolioServices;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionStrings")));

builder.Services.AddScoped<IServiceIdeas, ServiceIdeas>();
builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();


// Add services to the container.

builder.Services.AddControllers()
  .AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
