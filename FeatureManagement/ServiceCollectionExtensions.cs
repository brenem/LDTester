using Microsoft.Extensions.DependencyInjection;
using OpenFeature;

namespace FeatureManagement
{
    public static class ServiceCollectionExtensions
    {
        public static async Task<IServiceCollection> AddFeatureManagementAsync(this IServiceCollection services, Func<FeatureProvider> providerOptions)
        {
            var provider = providerOptions();
            await Api.Instance.SetProviderAsync(provider);

            IFeatureClient client = Api.Instance.GetClient();

            services.AddSingleton(client);
            services.AddSingleton<IFeatureFlagClient, FeatureFlagClient>();

            return services;
        }
    }
}
