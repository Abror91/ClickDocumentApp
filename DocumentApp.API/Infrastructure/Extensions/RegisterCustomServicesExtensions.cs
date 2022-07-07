using DocumentApp.BLL.Services.Abstractions;
using DocumentApp.BLL.Services.Implementations;
using DocumentApp.DAL.Repositories.Abstractions;
using DocumentApp.DAL.Repositories.Implementations;

namespace DocumentApp.API.Infrastructure.Extensions
{
    public static class RegisterCustomServicesExtensions
    {
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>();

            return services;
        }
    }
}
