using System;
using System.Collections.Generic;
using ElasticSearchPoC.Common.SearchParams;
using ElasticSearchPoC.SearchStage.Querying;
using ElasticSearchPoC.SearchStage.Sorting;
using Nest;
using Version = ElasticSearchPoC.Common.Models.Version;

namespace ElasticSearchPoC.SearchStage.SearchRunners
{
    public class VersionSearchRunner : DocumentSearchRunner<Version, VersionSearchParams>, IDocumentSearchRunner
    {
        private readonly string _indexName;

        public VersionSearchRunner(
            ElasticClient elasticClient,
            IEnumerable<ISortDescriptorProvider<Version>> sortDescriptors,
            IQueryContainerProvider<VersionSearchParams> queryDescriptorDescriptor)
            : base(elasticClient, sortDescriptors, queryDescriptorDescriptor)
        {
            RunnerType = typeof(VersionSearchParams);

            _indexName = "versions";
        }

        public Type RunnerType { get; }

        public ISearchResponse<object> Search(DocumentSearchParams searchParams)
        {
            return Search(_indexName, searchParams as VersionSearchParams);
        }
    }
}