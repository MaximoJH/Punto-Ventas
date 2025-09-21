using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Inventory.Mappings;

namespace Inventory.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
