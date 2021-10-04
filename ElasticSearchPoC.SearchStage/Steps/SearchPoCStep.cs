using System;
using System.Collections.Generic;
using System.Linq;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.PipelineStageSteps;
using ElasticSearchPoC.SearchStage.SearchRunners;

namespace ElasticSearchPoC.SearchStage.Steps
{
    public class SearchPoCStep : StageStep<PipelineState>
    {
        private readonly IEnumerable<IDocumentSearchRunner> _searchRunners;

        public SearchPoCStep(IEnumerable<IDocumentSearchRunner> searchRunners)
        {
            PipelineStage = PipelineStage.Search;

            _searchRunners = searchRunners;
        }

        public override void Run(PipelineState pipelineState)
        {
            var searchRunner = _searchRunners.FirstOrDefault(x => x.RunnerType == pipelineState.SearchParams.GetType());

            if (searchRunner == null)
            {
                throw new NotSupportedException("Not supported searchRunner type.");
            }

            var searchResult = searchRunner.Search(pipelineState.SearchParams);
            pipelineState.SearchResponse = searchResult;

            base.Run(pipelineState);
        }
    }
}