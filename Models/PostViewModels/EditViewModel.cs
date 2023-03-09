using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WebBlog.Data.Models;

namespace WebBlog.Models.PostViewModels
{
    public class EditViewModel
    {
        [Display(Name = "Header Image")]
        public IFormFile HeaderImage { get; set; } = default!;
        public Post Post { get; set; } = default!;
    }
}
