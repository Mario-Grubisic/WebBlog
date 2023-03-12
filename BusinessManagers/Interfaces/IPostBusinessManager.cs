using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebBlog.Data.Models;
using WebBlog.Models.PostViewModels;

namespace WebBlog.BusinessManagers.Interfaces
{
    public interface IPostBusinessManager
    {
        Models.HomeViewModel.IndexViewModel GetIndexViewModel(string searchString, int? page);
        Task<ActionResult<PostViewModel>> GetPostViewModel(int? id, ClaimsPrincipal claimsPrincipal);
        Task<Post> CreatePost(CreateViewModel createPostViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<Comment>> CreateComment(PostViewModel postViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> UpdatePost(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);
    }
}
