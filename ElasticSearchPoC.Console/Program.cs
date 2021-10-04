using System;
using ElasticSearchPoC.Common.Enums;
using ElasticSearchPoC.Common.Models;
using ElasticSearchPoC.Common.SearchParams;
using Version = System.Version;

namespace ElasticSearchPoC.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchRepository = ServicesProvider.ElasticSearchRepository;

            // search by Id example
            var applicationSearchByIdParams = new ApplicationSearchParams { Id = 1 };

            // full text search example
            var applicationFullTextSearchParams = new ApplicationSearchParams { SearchValue = "test search value" };

            // multi params search example
            var applicationMultiSearchParams = new ApplicationSearchParams
            {
                SearchValue = "test search value", 
                SortBy = DocumentSortBy.Recent,
                UpdatedOnRange = (DateTime.Now.AddDays(-1), DateTime.Now)
            };

            // search request example

            System.Console.WriteLine("\nFirst search:");
            var applications = searchRepository.Search<Application>(applicationSearchByIdParams);

            System.Console.WriteLine("\nSecond search:");
            var versions = searchRepository.Search<Version>(new VersionSearchParams());

            System.Console.ReadKey();
        }
    }
}
