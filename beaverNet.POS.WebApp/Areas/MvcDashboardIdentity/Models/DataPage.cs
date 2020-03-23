using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace beaverNet.POS.WebApp.Areas.MvcDashboardIdentity.Models
{
    public abstract class DataPage
    {
        public int FirstPage { get; private set; } = 1;

        public int LastPage
        {
            get
            {
                return (this.FilteredCount + this.PageSize - 1) / this.PageSize;
            }
        }

        public int CurrentPage { get; set; }

        public int PageCount
        {
            get
            {
                return (this.LastPage - this.FirstPage);
            }
        }

        public int PageSize { get; set; }

        public int FullCount { get; set; }

        public string Filter { get; set; }

        public int FilteredCount { get; set; }
    }

    public class DataPage<T> : DataPage
    {
        public T[] Items { get; set; }
    }
}
