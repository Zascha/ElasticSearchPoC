using ElasticSearchPoC.Common.Chain;
using ElasticSearchPoC.Common.Enums;

namespace ElasticSearchPoC.Common.PipelineStageSteps
{
    public interface IStageStep<T> : IChainStep<T>
    {
        PipelineStage PipelineStage { get; }
    }
}