using System;
using ElasticSearchPoC.Common.SearchParams;
using Nest;

namespace ElasticSearchPoC.SearchStage.SearchRunners
{
    public interface IDocumentSearchRunner
    {
        Type RunnerType { get; }

        ISearchResponse<object> Search(DocumentSearchParams searchParams);
    }
}