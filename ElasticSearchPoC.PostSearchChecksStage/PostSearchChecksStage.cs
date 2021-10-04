using System.Collections.Generic;
using System.Linq;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStages;
using ElasticSearchPoC.Common.PipelineStageSteps;

namespace ElasticSearchPoC.PostSearchChecksStage
{
    public class PostSearchChecksStage : PipelineStage<PipelineState>
    {
        public PostSearchChecksStage(IEnumerable<IStageStep<PipelineState>> steps)
            : base(steps.Where(x => x.PipelineStage == PipelineStage.PostSearch))
        {
        }
    }
}
