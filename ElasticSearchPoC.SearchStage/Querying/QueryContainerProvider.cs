using System.Collections.Generic;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.SearchParams;
using ElasticSearchPoC.SearchStage.Querying.Extensions;
using Nest;

namespace ElasticSearchPoC.SearchStage.Querying
{
    public abstract class QueryContainerProvider : IQueryContainerProvider<DocumentSearchParams>
    {
        public DocumentType DocumentsType { get; protected set; }

        public QueryContainer GetQueryContainer(DocumentSearchParams searchParams)
        {
            var queryContainer = new QueryContainer();

            if (searchParams.Id != 0)
            {
                queryContainer.AddFieldMatchingConcreteValue<Document>(nameof(Document.Id), searchParams.Id);
            }

            if (!string.IsNullOrEmpty(searchParams.SearchValue))
            {
                queryContainer.AddStringFieldFullTextSearch<Document>(new List<string> { nameof(Document.Title) }, searchParams.SearchValue, isConcreteMatch: false);
            }

            if (searchParams.UpdatedOnRange.From.HasValue || searchParams.UpdatedOnRange.To.HasValue)
            {
                queryContainer.AddDateTimeFieldIsInRange<Document>(nameof(Document.UpdatedOn), searchParams.UpdatedOnRange.From, searchParams.UpdatedOnRange.To);
            }

            return queryContainer;
        }
    }
}