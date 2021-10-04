namespace ElasticSearchPoC.Common.Models.PipelineStateParams
{
    
    public class PreSearchValidationParams
    {
        // An analogue of 'AppPlatform.ElasticSearch.Utility.Settings'
        public string ElasticSearchEndpoint { get; set; }

        public string ElasticSearchIndex { get; set; }
    }
}