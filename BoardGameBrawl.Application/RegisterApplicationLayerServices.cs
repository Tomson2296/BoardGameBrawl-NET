using Microsoft.Extensions.DependencyInjection;

namespace BoardGameBrawl.Application
{
    public static class RegisterApplicationLayerServices
    {
        public static Task<IServiceCollection> RegisterApplicationServices(this IServiceCollection services)
        {


            return Task.FromResult(services);
        }
    }
}
