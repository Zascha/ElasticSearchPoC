using System;
using System.Collections.Generic;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.SearchParams;
using ElasticSearchPoC.SearchStage.Querying;
using ElasticSearchPoC.SearchStage.Sorting;
using Nest;

namespace ElasticSearchPoC.SearchStage.SearchRunners
{
    public class ApplicationSearchRunner : DocumentSearchRunner<Application, ApplicationSearchParams>, IDocumentSearchRunner
    {
        private readonly string _indexName;

        public ApplicationSearchRunner(
            ElasticClient elasticClient,
            IEnumerable<ISortDescriptorProvider<Application>> sortDescriptors,
            IQueryContainerProvider<ApplicationSearchParams> queryDescriptorDescriptor)
            : base(elasticClient, sortDescriptors, queryDescriptorDescriptor)
        {
            RunnerType = typeof(ApplicationSearchParams);

            _indexName = "manifests";
        }

        public Type RunnerType { get; }

        public ISearchResponse<object> Search(DocumentSearchParams searchParams)
        {
            return Search(_indexName, searchParams as ApplicationSearchParams);
        }
    }
}