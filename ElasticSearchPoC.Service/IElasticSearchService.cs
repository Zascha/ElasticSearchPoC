using System.Collections.Generic;
using ElasticSearchPoC.Common.SearchParams;

namespace ElasticSearchPoC.Service
{
    public interface IElasticSearchService
    {
        List<T> Search<T>(DocumentSearchParams searchParams);
    }
}