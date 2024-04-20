using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangament.Core.IRepository
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<IList<Post>> GetAllPosts();
        Task<IList<Post>> GetPublishedPosts();
        Task<IList<Post>> GetUnpublishedPosts();
        Task<IList<Post>> GetPostsByMonth(DateTime monthYear);
        Task<Post> FindPost(int year, int month);
        Task<Post> FindPost(int id);
    }
}
