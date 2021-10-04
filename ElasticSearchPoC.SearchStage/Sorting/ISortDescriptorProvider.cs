using ElasticSearchPoC.Common.Enums;
using Nest;

namespace ElasticSearchPoC.SearchStage.Sorting
{
    public interface ISortDescriptorProvider<T> where T : class
    {
        DocumentSortBy SortByField { get; }

        SortDescriptor<T> GetSortDescriptor(DocumentSortOrder sortOrder);
    }
}
