using PagedList.Core;
using WebBlog.Data.Models;

namespace WebBlog.Models.HomeViewModel
{
    public class IndexViewModel
    {
        public IPagedList<Post> Posts { get; set; } = default!;
        public string SearchString { get; set; } = string.Empty;
        public int PageNumber { get; set; }
    }
}
