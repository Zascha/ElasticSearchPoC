using ElasticSearchPoC.Common.Enums;
using Nest;

namespace ElasticSearchPoC.SearchStage.Sorting.Application
{
    public class IsBlockedSortDescriptorProvider: SortDescriptorProvider<Common.Models.Application>, ISortDescriptorProvider<Common.Models.Application>
    {
        public IsBlockedSortDescriptorProvider()
        {
            SortByField = DocumentSortBy.IsBlocked;
        }

        public DocumentSortBy SortByField { get; }

        public SortDescriptor<Common.Models.Application> GetSortDescriptor(DocumentSortOrder sortOrder)
        {
            // one can add an additional logic here:

            // as 'IsBlocked' is a nullable bool field, one should choose 'GetSortByOptionalField'
            return GetSortByOptionalField(SortByField, sortOrder);
        }
    }
}