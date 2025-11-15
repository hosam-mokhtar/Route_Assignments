using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortingOptions SortingOption { get; set; }
        public string? SearchValue { get; set; }

        #region Pagination

        private const int DefaultPageSize = 5;
        private const int MaxPageSize = 10;

        public int PageIndex { get; set; } = 1;
        private int pageSize;

        public int PageSize
        {
            //get { return pageSize; }
            get => pageSize;
            set { pageSize = value > MaxPageSize ? DefaultPageSize : value; }
        }

        //public bool IsPaginated { get; set; }

        #endregion
    }
}
