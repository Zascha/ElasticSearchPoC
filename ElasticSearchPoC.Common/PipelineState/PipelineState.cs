using System.Collections.Generic;
using ElasticSearchPoC.Common.Models.PipelineStateParams;
using ElasticSearchPoC.Common.SearchParams;
using Nest;

namespace ElasticSearchPoC.Common.Models
{
    public class PipelineState
    {
        public PipelineState(
            PreSearchValidationParams preSearchValidationParams,
            DocumentSearchParams documentSearchParams)
        {
            PreSearchValidationParams = preSearchValidationParams;
            SearchParams = documentSearchParams;

            SearchResponse = new SearchResponse<object>();
            PipelineSearchResult = new List<object>();
        }

        public PreSearchValidationParams PreSearchValidationParams { get; set; }

        public DocumentSearchParams SearchParams { get; set; }

        public ISearchResponse<object> SearchResponse { get; set; }

        public List<object> PipelineSearchResult { get; set; }
    }
}