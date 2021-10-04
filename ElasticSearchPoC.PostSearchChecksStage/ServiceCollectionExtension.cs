using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStages;
using ElasticSearchPoC.Common.PipelineStageSteps;
using ElasticSearchPoC.PostSearchChecksStage.Steps;
using Microsoft.Extensions.DependencyInjection;

namespace ElasticSearchPoC.PostSearchChecksStage
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPostSearchChecksStageServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<IStageStep<PipelineState>, CheckOperationResponseValidityStep>()
                .AddSingleton<IStageStep<PipelineState>, CheckSearchResponseExecutionTimeValidityStep>()
                .AddSingleton(typeof(IPipelineStage<PipelineState>), typeof(PostSearchChecksStage));
        }
    }
}