using System;

namespace ElasticSearchPoC.Common.Models
{
    public class Document
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}