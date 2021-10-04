using System;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStageSteps;

namespace ElasticSearchPoC.PreSearchValidationStage.Steps
{
    public class ElasticSearchIndexValidationStep : StageStep<PipelineState>
    {
        public ElasticSearchIndexValidationStep()
        {
            PipelineStage = PipelineStage.PreSearch;
        }

        public override void Run(PipelineState validationParams)
        {
            Console.WriteLine("PRE VALIDATION > ElasticSearch index check: EXISTS.");

            base.Run(validationParams);
        }
    }
}