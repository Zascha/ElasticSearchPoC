using ElasticSearchPoC.Common.Enums;

namespace ElasticSearchPoC.Common.SearchParams
{
    public class ApplicationSearchParams : DocumentSearchParams
    {
        public ApplicationSearchParams()
        {
            DocumentType = DocumentType.Application;
        }

        public bool IncludeBlocked { get; set; }
    }
}