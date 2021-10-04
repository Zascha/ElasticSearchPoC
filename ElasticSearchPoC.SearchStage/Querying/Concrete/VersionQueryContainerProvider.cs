using System.Linq;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.SearchParams;
using ElasticSearchPoC.SearchStage.Querying.Extensions;
using Nest;

namespace ElasticSearchPoC.SearchStage.Querying
{
    public class VersionQueryContainerProvider : QueryContainerProvider, IQueryContainerProvider<VersionSearchParams>
    {
        public VersionQueryContainerProvider()
        {
            DocumentsType = DocumentType.Version;
        }

        public QueryContainer GetQueryContainer(VersionSearchParams searchParams)
        {
            var queryContainer = base.GetQueryContainer(searchParams);

            queryContainer.AddFieldMatchingAnyOfValues<Version>(nameof(Version.VersionNumber), searchParams.VersionNumbers.Cast<object>());

            return queryContainer;
        }
    }
}