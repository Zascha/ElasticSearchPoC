using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStages;
using ElasticSearchPoC.Common.PipelineStageSteps;
using ElasticSearchPoC.Common.SearchParams;
using ElasticSearchPoC.SearchStage.Querying;
using ElasticSearchPoC.SearchStage.SearchRunners;
using ElasticSearchPoC.SearchStage.Sorting;
using ElasticSearchPoC.SearchStage.Sorting.Application;
using ElasticSearchPoC.SearchStage.Sorting.Document;
using Microsoft.Extensions.DependencyInjection;

namespace ElasticSearchPoC.SearchStage
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSearchStageServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<ISortDescriptorProvider<Document>, RecentSortDescriptorProvider>()
                .AddSingleton<ISortDescriptorProvider<Document>, TitleSortDescriptorProvider>()
                .AddSingleton<ISortDescriptorProvider<Application>, IsBlockedSortDescriptorProvider>();

            serviceCollection
                .AddSingleton<IQueryContainerProvider<ApplicationSearchParams>, ApplicationQueryContainerProvider>()
                .AddSingleton<IQueryContainerProvider<VersionSearchParams>, VersionQueryContainerProvider>();

            serviceCollection
                .AddSingleton<IDocumentSearchRunner, ApplicationSearchRunner>()
                .AddSingleton<IDocumentSearchRunner, VersionSearchRunner>();

            serviceCollection
                .AddSingleton<IStageStep<PipelineState>, Steps.SearchStep>()
                .AddSingleton(typeof(IPipelineStage<PipelineState>), typeof(SearchStage));
        }
    }
}