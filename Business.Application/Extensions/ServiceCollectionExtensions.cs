using Business.Application.Services.Organizations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddArtBookingBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IArtOrganizationService, ArtOrganizationService>();
            return services;
        }
    }
}