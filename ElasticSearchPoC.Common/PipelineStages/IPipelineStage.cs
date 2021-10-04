using ElasticSearchPoC.Common.Chain;

namespace ElasticSearchPoC.Common.PipelineStages
{
    public interface IPipelineStage<T> : IChainStep<T>
    {
    }
}