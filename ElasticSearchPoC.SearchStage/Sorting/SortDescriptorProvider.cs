using ElasticSearchPoC.Common.Enums;
using Nest;

namespace ElasticSearchPoC.SearchStage.Sorting
{
    public abstract class SortDescriptorProvider<T> where T : class
    {
        private const string KeywordSuffix = "keyword";

        protected SortDescriptor<T> GetSortByRequiredNotStringField(DocumentSortBy sortByField, DocumentSortOrder sortOrder)
        {
            var field = new Field(sortByField.GetDisplayValue());

            return sortOrder == DocumentSortOrder.Asc
                ? new SortDescriptor<T>().Ascending(field)
                : new SortDescriptor<T>().Descending(field);
        }

        protected SortDescriptor<T> GetSortByStringField(DocumentSortBy sortByField, DocumentSortOrder sortOrder)
        {
            // To enable sorting by string field
            // https://stackoverflow.com/questions/46979724/nest-sort-by-text-field
            return sortOrder == DocumentSortOrder.Asc
                ? new SortDescriptor<T>().Ascending(x => x.GetType().GetProperty(sortByField.GetDisplayValue()).Suffix(KeywordSuffix))
                : new SortDescriptor<T>().Descending(x => x.GetType().GetProperty(sortByField.GetDisplayValue()).Suffix(KeywordSuffix));
        }

        protected SortDescriptor<T> GetSortByOptionalField(DocumentSortBy sortByField, DocumentSortOrder sortOrder)
        {
            // 'Painless' language script
            // https://www.elastic.co/guide/en/elasticsearch/reference/master/modules-scripting-painless.html
            var sortSource = $"if (doc['{sortByField.GetDisplayValue()}'].size() > 0 && doc['{sortByField.GetDisplayValue()}'].value >= 0L) {{ return 1; }} else {{ return 0; }}";

            var sortingField = new Field(sortByField.GetDisplayValue());
            var sortDescriptor = new SortDescriptor<T>().Script(sc => sc.Type("number").Descending().Script(script => script.Source(sortSource)));

            return sortOrder == DocumentSortOrder.Asc
                   ? sortDescriptor.Ascending(sortingField)
                   : sortDescriptor.Descending(sortingField);
        }
    }
}