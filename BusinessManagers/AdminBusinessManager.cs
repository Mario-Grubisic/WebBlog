using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebBlog.BusinessManagers.Interfaces;
using WebBlog.Models;
using WebBlog.Models.AdminViewModels;
using WebBlog.Services.Interfaces;

namespace WebBlog.BusinessManagers
{
    public class AdminBusinessManager : IAdminBusinessManager
    {
        private UserManager<ApplicationUser> userManager;
        private IPostService postService;

        public AdminBusinessManager(UserManager<ApplicationUser> userManager,
            IPostService postService)
        {
            this.userManager = userManager;
            this.postService = postService;
        }

        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal)
        {
            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);
            return new IndexViewModel
            {
                Posts = postService.GetPosts(applicationUser)
            };
        }
    }
}
