using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BusinessModels
{
    public class PagedList<T>
    {
        public PagingModel Paging { get; set; }

        public List<T> TableList{ get; set; }
    }
}
