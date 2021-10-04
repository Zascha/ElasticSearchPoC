using System.Collections.Generic;
using ElasticSearchPoC.Common.Enums;

namespace ElasticSearchPoC.Common.SearchParams
{
    public class VersionSearchParams : DocumentSearchParams
    {
        public VersionSearchParams()
        {
            DocumentType = DocumentType.Version;
        }

        public List<int> VersionNumbers { get; set; }
    }
}