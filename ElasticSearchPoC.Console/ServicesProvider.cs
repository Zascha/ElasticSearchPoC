using ElasticSearchPoC.PostSearchChecksStage;
using ElasticSearchPoC.PreSearchValidationStage;
using ElasticSearchPoC.SearchStage;
using ElasticSearchPoC.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ElasticSearchPoC.Console
{
    public static class ServicesProvider
    {
        private static ServiceProvider _serviceProvider;

        static ServicesProvider()
        {
            BuildServicesProvider();
        }

        public static IElasticSearchService ElasticSearchRepository => _serviceProvider.GetService<IElasticSearchService>();

        private static void BuildServicesProvider()
        {
            var services = new ServiceCollection();

            services.AddPreSearchValidationStageServices();
            services.AddSearchStageServices();
            services.AddPostSearchChecksStageServices();

            services.AddSingleton<IElasticSearchService, ElasticSearchService>();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}