using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreApplication.Domain.Domain
{
    public class PagedSortedList<T>
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public SortOrder SortOrder { get; set; }
        public string? SortBy { get; set; }
        public List<T>? Items { get; set; }
    }
}
