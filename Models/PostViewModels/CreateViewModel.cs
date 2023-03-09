using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using WebBlog.Data.Models;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace WebBlog.Models.PostViewModels
{
    public class CreateViewModel
    {
        [Required, Display(Name = "Header Image")]
        public IFormFile HeaderImage { get; set; } = default!;
        public Post Post { get; set; } = default!;
    }
}
