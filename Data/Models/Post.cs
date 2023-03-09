using WebBlog.Models;

namespace WebBlog.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public ApplicationUser Creator { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public bool Published { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; } = default!;
    }
}
