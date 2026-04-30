using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Common
{
    public class SearchQuery<T> where T : class
    {
        public SearchQuery()
        {
            this.StartPageNo = 1;
            this.EndPageNo = 0;
            
        }

        [FromQuery]
        public T Filter { get; set; }

        [FromQuery]
        public string SortExpression { get; set; }

        [FromQuery]
        public int? StartPageNo { get; set; }

        [FromQuery]
        public int? EndPageNo { get; set; }

        [FromQuery]
        public int? PageSize { get; set; }

        [FromQuery]
        public bool RunCount { get; set; }

    }
}
