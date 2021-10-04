using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.Models.PipelineStateParams;
using ElasticSearchPoC.Common.PipelineStages;
using ElasticSearchPoC.Common.PipelineStageSteps;
using ElasticSearchPoC.PreSearchValidationStage.Steps;
using Microsoft.Extensions.DependencyInjection;

namespace ElasticSearchPoC.PreSearchValidationStage
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPreSearchValidationStageServices(this IServiceCollection serviceCollection)
        {
            var preSearchValidationParams = new PreSearchValidationParams
            {
                ElasticSearchIndex = "test-index",
                ElasticSearchEndpoint = "http://localhost:9200"
            };

            serviceCollection
                .AddSingleton(preSearchValidationParams)
                .AddTransient<IStageStep<PipelineState>, ElasticSearchAvailabilityValidationStep>()
                .AddTransient<IStageStep<PipelineState>, ElasticSearchIndexValidationStep>()
                .AddTransient<IPipelineStage<PipelineState>, PreSearchValidationStage>();
        }
    }
}