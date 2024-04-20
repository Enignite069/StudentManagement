using StudentManagement.ViewModels;
using StudentMangament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Service.PostService
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPosts();
        Task<IEnumerable<Post>> GetPublishedPosts();
        Task<IEnumerable<Post>> GetUnpublishedPosts();
        Task<Post> GetPostsDetails(int id);
        Task<Post> GetPostsDetails(int year, int month);
        Task AddPost(PostCreateVM post);
        Task EditPost(PostCreateVM post, int id);
        Task DeletePost(int postId);
        Task<Post> FindPostById(int id);
    }
}
