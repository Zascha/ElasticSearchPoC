using System;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStageSteps;

namespace ElasticSearchPoC.SearchStage.Steps
{
    public class SearchStep : StageStep<PipelineState>
    {
        public SearchStep()
        {
            PipelineStage = PipelineStage.Search;
        }

        public override void Run(PipelineState searchParams)
        {
            Console.WriteLine("SEARCH > Finished.");

            base.Run(searchParams);
        }
    }
}