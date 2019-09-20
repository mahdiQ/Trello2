using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BusinessModels
{
    public class PagingModel
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int PagesCount { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }
    }
}
