using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
