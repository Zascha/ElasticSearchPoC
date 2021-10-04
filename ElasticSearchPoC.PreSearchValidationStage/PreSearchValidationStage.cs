using ElasticSearchPoC.Common.PipelineStages;
using System.Collections.Generic;
using System.Linq;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStageSteps;

namespace ElasticSearchPoC.PreSearchValidationStage
{
    public class PreSearchValidationStage : PipelineStage<PipelineState>
    {
        // Is injected using DI. The order is set in 'ServiceCollectionExtensions.cs'
        // https://stackoverflow.com/questions/60566047/does-asp-net-cores-di-container-assures-order-of-services
        public PreSearchValidationStage(IEnumerable<IStageStep<PipelineState>> steps)
            : base(steps.Where(x => x.PipelineStage == PipelineStage.PreSearch))
        {
        }
    }
}
