using System;
using ElasticSearchPoC.Common.Enums;

namespace ElasticSearchPoC.Common.SearchParams
{
    public abstract class DocumentSearchParams
    {
        protected DocumentSearchParams()
        {
            Take = 50;
        }

        public int Id { get; set; }

        public string SearchValue { get; set; }

        public (DateTime? From, DateTime? To) UpdatedOnRange { get; set; }

        protected DocumentType DocumentType { get; set; }

        public DocumentSortBy SortBy { get; set; }

        public DocumentSortOrder SortOrder { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }
    }
}