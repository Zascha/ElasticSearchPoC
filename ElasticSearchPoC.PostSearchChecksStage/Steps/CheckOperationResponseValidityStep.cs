using System;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStageSteps;

namespace ElasticSearchPoC.PostSearchChecksStage.Steps
{
    // An analogue to 'AppPlatform.ElasticSearch.Services.Extensions.ElasticSearchExtensions'
    public class CheckOperationResponseValidityStep : StageStep<PipelineState>
    {
        public CheckOperationResponseValidityStep()
        {
            PipelineStage = PipelineStage.PostSearch;
        }

        public override void Run(PipelineState validationParams)
        {
            Console.WriteLine("POST CHECK > Operation response not null check: PASSED.");

            Console.WriteLine("POST CHECK > Operation response ApiCall.Success check: PASSED.");

            Console.WriteLine("POST CHECK > Operation response IsValid check: PASSED.");

            base.Run(validationParams);
        }
    }
}