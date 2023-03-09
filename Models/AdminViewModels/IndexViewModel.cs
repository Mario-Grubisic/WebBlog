using WebBlog.Data.Models;

namespace WebBlog.Models.AdminViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Post> Posts { get; set; } = default!;
    }
}
