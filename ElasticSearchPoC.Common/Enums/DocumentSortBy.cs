using System.ComponentModel.DataAnnotations;

namespace ElasticSearchPoC.Common.Enums
{
    public enum DocumentSortBy
    {
        Relevance,

        [Display(Name = "UpdatedOn")]
        Recent, // DateTime value

        [Display(Name="Title")]
        Title, // String value

        [Display(Name = "IsBlocked")]
        IsBlocked // Bool value
    }
}