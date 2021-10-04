using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.SearchParams;
using ElasticSearchPoC.SearchStage.Querying.Extensions;
using Nest;

namespace ElasticSearchPoC.SearchStage.Querying
{
    public class ApplicationQueryContainerProvider : QueryContainerProvider, IQueryContainerProvider<ApplicationSearchParams>
    {
        public ApplicationQueryContainerProvider()
        {
            DocumentsType = DocumentType.Application;
        }

        public QueryContainer GetQueryContainer(ApplicationSearchParams searchParams)
        {
            var queryContainer = base.GetQueryContainer(searchParams);

            queryContainer.AddFieldMatchingConcreteValue<Application>(nameof(Application.IsBlocked), searchParams.IncludeBlocked, isOptionalField: true);

            return queryContainer;
        }
    }
}