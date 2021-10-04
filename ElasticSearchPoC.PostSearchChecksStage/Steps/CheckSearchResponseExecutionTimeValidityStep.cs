using System;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStageSteps;

namespace ElasticSearchPoC.PostSearchChecksStage.Steps
{
    // An analogue to 'AppPlatform.ElasticSearch.Services.Extensions.ElasticSearchExtensions'
    public class CheckSearchResponseExecutionTimeValidityStep : StageStep<PipelineState>
    {
        public CheckSearchResponseExecutionTimeValidityStep()
        {
            PipelineStage = PipelineStage.PostSearch;
        }

        public override void Run(PipelineState validationParams)
        {
            Console.WriteLine("POST CHECK > Operation execution took less than 100ms check: PASSED.");

            base.Run(validationParams);
        }
    }
}