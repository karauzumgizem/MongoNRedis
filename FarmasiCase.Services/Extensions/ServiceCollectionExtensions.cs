using FarmasiCase.Data.Abstract;
using FarmasiCase.Data.Concrete;
using FarmasiCase.Data.Concrete.EntityFramework.Repositories;
using FarmasiCase.Services.Abstract;
using FarmasiCase.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace FarmasiCase.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
           
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IBasketService, BasketService>();
            //serviceCollection.AddSingleton<ICacheService, RedisCacheService>();
            return serviceCollection;
        }
    }
}
