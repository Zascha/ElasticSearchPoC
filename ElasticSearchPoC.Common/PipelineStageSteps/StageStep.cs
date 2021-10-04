using ElasticSearchPoC.Common.Chain;
using ElasticSearchPoC.Common.Enums;

namespace ElasticSearchPoC.Common.PipelineStageSteps
{
    public abstract class StageStep<T> : ChainStep<T>, IStageStep<T>
    {
        public PipelineStage PipelineStage { get; protected set; }
    }
}