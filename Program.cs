
using ApplicationSettingConfiguration.Domain;
using ApplicationSettingConfiguration.Service;
using Microsoft.Extensions.Options;

namespace ApplicationSettingConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LoggerFactory.Create(config => config.AddConsole()).CreateLogger<Program>();

            try
            {
                var builder = WebApplication.CreateBuilder(args);

                //binds the ApiSettings class to the ApiConfiguration section in appsettings.json
                builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiConfiguration"));

                // Register the ApiSettings class with the DI container
                builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<ApiSettings>>().Value);
                builder.Services.AddSingleton<IApiUrlResolver, ApiUrlResolver>();


                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddHttpClient();

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
            }
            catch (Exception ex)
            {
                logger.LogCritical($"An error occurred while starting the application.{ex}");
            }
        }
    }
}
