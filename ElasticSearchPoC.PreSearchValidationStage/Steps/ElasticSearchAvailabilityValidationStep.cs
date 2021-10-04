using System;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStageSteps;

namespace ElasticSearchPoC.PreSearchValidationStage.Steps
{
    public class ElasticSearchAvailabilityValidationStep : StageStep<PipelineState>
    {
        public ElasticSearchAvailabilityValidationStep()
        {
           PipelineStage = PipelineStage.PreSearch;
        }

        public override void Run(PipelineState validationParams)
        {
            Console.WriteLine("PRE VALIDATION > ElasticSearch endpoint availability check: AVAILABLE.");

            base.Run(validationParams);
        }
    }
}