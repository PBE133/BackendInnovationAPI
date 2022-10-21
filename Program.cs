using BackendInnovationAPI.Services.IdeaServices;
using BackendInnovationAPI.Services.PortfolioServices;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace BackendInnovationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.Configure<DatabaseSettings.DatabaseSettings>(
                builder.Configuration.GetSection(nameof(DatabaseSettings.DatabaseSettings)));

            builder.Services.AddSingleton<DatabaseSettings.IDatabaseSettings>(sp =>
            sp.GetRequiredService<IOptions<DatabaseSettings.DatabaseSettings>>().Value);

            builder.Services.AddSingleton<IMongoClient>(s =>
                    new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionStrings")));

            builder.Services.AddScoped<IServiceIdeas, ServiceIdeas>();
            //builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();
            builder.Services.AddScoped<IPortfolioService, PortfolioService>();


            // Add services to the container.

            builder.Services.AddControllers()
              .AddNewtonsoftJson();

            // for integration test the dependency is required
            builder.Services.AddHealthChecks();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "IdeaRepo API",

                });

            });


            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "Idea repo API - Swagger docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdeaRepo API v1");
                c.EnableDeepLinking();
                c.DefaultModelsExpandDepth(0);
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            //Interface implementation endpoint 
            app.MapHealthChecks("/healthcheck");

            app.MapControllers();

            app.Run();
        }
    }
}