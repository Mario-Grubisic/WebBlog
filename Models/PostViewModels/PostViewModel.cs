using WebBlog.Data.Models;

namespace WebBlog.Models.PostViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; } = default!;
        public Comment Comment { get; set; } = default!;
    }
}
