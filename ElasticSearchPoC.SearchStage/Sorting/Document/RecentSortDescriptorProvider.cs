using ElasticSearchPoC.Common.Enums;
using Nest;

namespace ElasticSearchPoC.SearchStage.Sorting.Document
{
    public class RecentSortDescriptorProvider: SortDescriptorProvider<Common.Models.Document>, ISortDescriptorProvider<Common.Models.Document>
    {
        public RecentSortDescriptorProvider()
        {
            SortByField = DocumentSortBy.Recent;
        }

        public DocumentSortBy SortByField { get; }

        public SortDescriptor<Common.Models.Document> GetSortDescriptor(DocumentSortOrder sortOrder)
        {
            // one can add an additional logic here:

            // as Recent expects a 'DateTime' field for sorting, one should choose 'GetSortByRequiredNotStringField'
            return GetSortByRequiredNotStringField(SortByField, sortOrder);
        }
    }
}