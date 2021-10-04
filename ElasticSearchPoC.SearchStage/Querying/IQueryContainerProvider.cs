using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.SearchParams;
using Nest;

namespace ElasticSearchPoC.SearchStage.Querying
{
    public interface IQueryContainerProvider<in T> where T : DocumentSearchParams
    {
        DocumentType DocumentsType { get; }

        QueryContainer GetQueryContainer(T searchParams);
    }
}