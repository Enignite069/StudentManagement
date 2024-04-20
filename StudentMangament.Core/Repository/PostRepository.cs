using Microsoft.EntityFrameworkCore;
using StudentMangament.Core.Data;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.IRepository;
using StudentMangament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMangament.Core.Repository
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Post> FindPost(int year, int month)
        {
            return await _DbContext.Posts.FirstOrDefaultAsync(it => it.PostedOn.Year == year && it.PostedOn.Month == month);
        }

        public async Task<Post> FindPost(int id)
        {
            return await _DbContext.Posts.FirstOrDefaultAsync(it => it.Id.Equals(id));
        }

        public async Task<IList<Post>> GetAllPosts()
        {
            return await _DbContext.Posts.ToListAsync();
        }

        public async Task<IList<Post>> GetPostsByMonth(DateTime monthYear)
        {
            return await _DbContext.Posts.Where(it => it.PostedOn.Month == monthYear.Month).ToListAsync();
        }

        public async Task<IList<Post>> GetPublishedPosts()
        {
            return await _DbContext.Posts.Where(it => it.Published == true).ToListAsync();
        }

        public async Task<IList<Post>> GetUnpublishedPosts()
        {
            return await _DbContext.Posts.Where(it => it.Published == false).ToListAsync();
        }
    }
}
