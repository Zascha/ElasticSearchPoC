using ElasticSearchPoC.Common.Enums;
using Nest;

namespace ElasticSearchPoC.SearchStage.Sorting.Document
{
    public class TitleSortDescriptorProvider : SortDescriptorProvider<Common.Models.Document>, ISortDescriptorProvider<Common.Models.Document>
    {
        public TitleSortDescriptorProvider()
        {
            SortByField = DocumentSortBy.Title;
        }

        public DocumentSortBy SortByField { get; }

        public SortDescriptor<Common.Models.Document> GetSortDescriptor(DocumentSortOrder sortOrder)
        {
            // one can add an additional logic here:
            sortOrder = sortOrder == DocumentSortOrder.Asc ? DocumentSortOrder.Desc : DocumentSortOrder.Asc;

            // as 'Title' is a string field, one should choose 'GetSortByOptionalField'
            return GetSortByStringField(SortByField, sortOrder);
        }
    }
}