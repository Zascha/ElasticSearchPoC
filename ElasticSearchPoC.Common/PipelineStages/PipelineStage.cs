
using System.Collections.Generic;
using System.Linq;
using ElasticSearchPoC.Common.Chain;
using ElasticSearchPoC.Common.PipelineStageSteps;

namespace ElasticSearchPoC.Common.PipelineStages
{
    public class PipelineStage<T> : ChainStep<T>, IPipelineStage<T>
    {
        private readonly IEnumerable<IStageStep<T>> _steps;

        public PipelineStage(IEnumerable<IStageStep<T>> steps)
        {
            _steps = steps;
            ChainStepsBuilder.BuildChain(_steps);
        }

        public override void Run(T stepParams)
        {
            if (_steps.Any())
            {
                _steps.First().Run(stepParams);
            }

            base.Run(stepParams);
        }
    }
}