using System.Collections.Generic;
using System.Linq;
using ElasticSearchPoC.Common.Chain;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.Models.PipelineStateParams;
using ElasticSearchPoC.Common.PipelineStages;
using ElasticSearchPoC.Common.SearchParams;

namespace ElasticSearchPoC.Service
{
    // An analogue of 'AppPlatform.ElasticSearch.Utility.Repository.ElasticSearchRepository'
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly PreSearchValidationParams _preSearchValidationParams;
        private readonly IPipelineStage<PipelineState> _pipelineEntryPoint;

        public ElasticSearchService(
            PreSearchValidationParams preSearchValidationParams,
            IEnumerable<IPipelineStage<PipelineState>> stages)
        {
            _preSearchValidationParams = preSearchValidationParams;

            _pipelineEntryPoint = stages.First();
            ChainStepsBuilder.BuildChain(stages);
        }

        public List<T> Search<T>(DocumentSearchParams searchParams)
        {
            var pipelineState = new PipelineState(_preSearchValidationParams, searchParams);

            _pipelineEntryPoint.Run(pipelineState);

            var pipelineResult = pipelineState.PipelineSearchResult.Select(x => (T)x).ToList();
            return pipelineResult;
        }
    }
}