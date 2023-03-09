using WebBlog.Models;

namespace WebBlog.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Post Post { get; set; } = default!;
        public ApplicationUser Author { get; set; } = default!;
        public string Content { get; set; } = default!;
        public Comment Parent { get; set; } = default!;
        public DateTime CreatedOn { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; } = default!;
    }
}
