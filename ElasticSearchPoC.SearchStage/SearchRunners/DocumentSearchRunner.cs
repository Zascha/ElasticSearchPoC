using System;
using System.Collections.Generic;
using System.Linq;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.SearchParams;
using ElasticSearchPoC.SearchStage.Querying;
using ElasticSearchPoC.SearchStage.Sorting;
using Nest;

namespace ElasticSearchPoC.SearchStage.SearchRunners
{
    public class DocumentSearchRunner<T, TR>
        where T : Document
        where TR : DocumentSearchParams
    {
        private readonly ElasticClient _elasticClient;
        private readonly IEnumerable<ISortDescriptorProvider<T>> _sortDescriptors;
        private readonly IQueryContainerProvider<TR> _queryDescriptorDescriptor;

        public DocumentSearchRunner(
            ElasticClient elasticClient,
            IEnumerable<ISortDescriptorProvider<T>> sortDescriptors,
            IQueryContainerProvider<TR> queryDescriptorDescriptor)
        {
            _elasticClient = elasticClient ?? throw new ArgumentNullException(nameof(elasticClient));
            _sortDescriptors = sortDescriptors ?? throw new ArgumentNullException(nameof(sortDescriptors));
            _queryDescriptorDescriptor = queryDescriptorDescriptor ?? throw new ArgumentNullException(nameof(queryDescriptorDescriptor));
        }

        public ISearchResponse<T> Search(string indexName, TR searchParams)
        {
            var query = GetDocumentQuery(searchParams);
            var sort = GetSortDescriptor(searchParams);

            var searchResult = _elasticClient.Search<T>(s =>
                s.Index(indexName)
                    .TrackScores()
                    .Query(q => query)
                    .Sort(ss => sort)
                    .From(searchParams.Skip)
                    .Size(searchParams.Take));

            return searchResult;
        }

        #region Private methods

        private QueryContainer GetDocumentQuery(TR searchParams)
        {
            if (_queryDescriptorDescriptor == null)
            {
                throw new NotSupportedException("Not supported 'queryDescriptor' value");
            }

            return _queryDescriptorDescriptor.GetQueryContainer(searchParams);
        }

        private SortDescriptor<T> GetSortDescriptor(TR searchParams)
        {
            var sortDescriptor = _sortDescriptors.FirstOrDefault(x => x.SortByField == searchParams.SortBy);
            if (sortDescriptor == null)
            {
                throw new NotSupportedException("Not supported 'SortBy' value");
            }

            return sortDescriptor.GetSortDescriptor(searchParams.SortOrder);
        }

        #endregion
    }
}