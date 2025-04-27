using Business.Application.Services.Organizations;
using Business.Application.Services.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Business.Application.Services.Venues;

namespace Business.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddArtBookingBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IArtOrganizationService, ArtOrganizationService>();
            services.AddScoped<IArtEventService, ArtEventService>();
            services.AddScoped<IVenueService, VenueService>();
            return services;
        }
    }
}