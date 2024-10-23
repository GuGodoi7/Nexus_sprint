using _NEXUS.Repository.Interfaces;
using _NEXUS.Repository;
using Microsoft.OpenApi.Models;
using Nexus.Configuration;
using NX.Database;

namespace Nexus.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = appConfiguration.Swagger.Title,
                    Version = "v1",
                    Description = appConfiguration.Swagger.Description,
                    Contact = new OpenApiContact() { Email = appConfiguration.Swagger.Email, Name = appConfiguration.Swagger.Name }
                });
            });

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<TaskUseCase>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Task>, Repository<Task>>();
            return services;
        }

        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddDbContext<NXContext>(options =>
            {
                options.UseMongoDB(appConfiguration.MongoDbConnectionString, appConfiguration.MongoDbDatabase);
            });
            return services;
        }
    }
}