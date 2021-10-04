using System;
using System.Collections.Generic;
using System.Linq;
using Nest;

namespace ElasticSearchPoC.SearchStage.Querying.Extensions
{
    public static class QueryContainerExtensions
    {
        // field equals value
        public static QueryContainer AddFieldMatchingConcreteValue<T>(this QueryContainer queryContainer, string matchFieldName, object matchValue, bool isOptionalField = false) where T : class
        {
            var matchField = new Field(matchFieldName);
            var queryContainerExpandingLogic = Query<T>.Term(t => t.Field(f => matchField).Value(matchValue));

            return ExpandQueryContainer<T>(queryContainer, queryContainerExpandingLogic, matchFieldName, isOptionalField);
        }

        // field is any of {value A, value B}
        public static QueryContainer AddFieldMatchingAnyOfValues<T>(this QueryContainer queryContainer, string matchFieldName, IEnumerable<object> matchValues, bool isOptionalField = false) where T : class
        {
            var matchField = new Field(matchFieldName);
            var queryContainerExpandingLogic = Query<T>.Terms(t => t.Field(f => matchField).Terms(matchValues));

            return ExpandQueryContainer<T>(queryContainer, queryContainerExpandingLogic, matchFieldName, isOptionalField);
        }

        // value A <= field <= value B
        public static QueryContainer AddNumericFieldIsInRange<T>(this QueryContainer queryContainer, string matchFieldName, double? startRangeValue, double? endRangeValue, bool isOptionalField = false) where T : class
        {
            var matchField = new Field(matchFieldName);
            var queryContainerExpandingLogic = Query<T>.Range(r => r.Field(f => matchField).GreaterThan(startRangeValue).LessThan(endRangeValue));

            return ExpandQueryContainer<T>(queryContainer, queryContainerExpandingLogic, matchFieldName, isOptionalField);
        }

        // value A <= field <= value B
        public static QueryContainer AddDateTimeFieldIsInRange<T>(this QueryContainer queryContainer, string matchFieldName, DateTime? startRangeValue, DateTime? endRangeValue, bool isOptionalField = false) where T : class
        {
            var matchField = new Field(matchFieldName);
            var queryContainerExpandingLogic = Query<T>.DateRange(r => r.Field(f => matchField).GreaterThan(startRangeValue).LessThan(endRangeValue));

            return ExpandQueryContainer<T>(queryContainer, queryContainerExpandingLogic, matchFieldName, isOptionalField);

        }

        public static QueryContainer AddStringFieldFullTextSearch<T>(this QueryContainer queryContainer, IEnumerable<string> fieldsNames, string searchValue, bool isConcreteMatch = true) where T : class
        {
            if (fieldsNames != null && fieldsNames.Any())
            {
                var fields = new Field(fieldsNames.First());

                foreach (var fieldName in fieldsNames.Skip(1))
                {
                    fields.And(new Field(fieldName));
                }

                var query = isConcreteMatch ? searchValue : $"*{searchValue.Trim()}*";

                queryContainer &= Query<T>.QueryString(m => m.Fields(fields)
                    .Query(query)
                    .DefaultOperator(Operator.And)
                    .Type(TextQueryType.MostFields));
            }

            return queryContainer;
        }

        #region Private methods

        private static QueryContainer AddOptionalFieldMatching<T>(QueryContainer queryContainer, Field matchField) where T : class
        {
            var queryContainerForOptionalField = Query<T>.Bool(b => b.Must(m => 
                m.Exists(d => d.Field(f => matchField)) && queryContainer
                || !m.Exists(d => d.Field(f => matchField))));

            return queryContainerForOptionalField;
        }

        public static QueryContainer ExpandQueryContainer<T>(QueryContainer queryContainerToExpand, QueryContainer queryContainerExpandingLogic, Field matchField, bool isOptionalField = false) where T : class
        {
            if (isOptionalField)
            {
                queryContainerExpandingLogic = AddOptionalFieldMatching<T>(queryContainerExpandingLogic, matchField);
            }

            queryContainerToExpand &= queryContainerExpandingLogic;

            return queryContainerToExpand;
        }

        #endregion
    }
}