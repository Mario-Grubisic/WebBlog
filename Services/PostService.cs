﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebBlog.BusinessManagers.Interfaces;
using WebBlog.Data;
using WebBlog.Data.Models;
using WebBlog.Models;
using WebBlog.Services.Interfaces;

namespace WebBlog.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public PostService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public Post GetPost(int postId)
        {
            return applicationDbContext.Posts
                .Include(post => post.Creator)
                .Include(post => post.Comments)
                    .ThenInclude(comment => comment.Author)
                .Include(post => post.Comments)
                    .Include(comment => comment.Comments)
                        .ThenInclude(reply => reply.Parent)
                .FirstOrDefault(post => post.Id == postId);
        }

        public IEnumerable<Post> GetPosts(string searchString)
        {
            return applicationDbContext.Posts
                .OrderByDescending(post => post.UpdatedOn)
                .Include(post => post.Creator)
                .Include(post => post.Comments)
                .Where(post => post.Title.Contains(searchString) || post.Content.Contains(searchString));

        }

        public IEnumerable<Post> GetPosts(ApplicationUser applicationUser) 
        {
            return applicationDbContext.Posts
                .Include(post => post.Creator)
                .Include(post => post.Comments)
                .Where(post => post.Creator == applicationUser);
        }

        public Comment GetComment(int commentId)
        {
            return applicationDbContext.Comments
                .Include(comment => comment.Author)
                .Include(comment => comment.Post)
                .Include(comment => comment.Parent)
                .FirstOrDefault(comment => comment.Id == commentId);
        }

        public async Task<Post> Add(Post post)
        {
            applicationDbContext.Add(post);
            await applicationDbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Comment> Add(Comment comment)
        {
            applicationDbContext.Add(comment);
            await applicationDbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Post> Update(Post post)
        {
            applicationDbContext.Update(post);
            await applicationDbContext.SaveChangesAsync();
            return post;
        }
    }
}
