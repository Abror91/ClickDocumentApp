using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DocumentApp.Models.ViewModels
{
    public class PaginationQueryParams
    {
        [BindRequired]
        public int Page { get; set; }

        [BindRequired]
        public int PerPage { get; set; }
    }
}
