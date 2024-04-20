using StudentManagement.ViewModels;
using StudentMangament.Core.Infrastructure;
using StudentMangament.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Service.PostService
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddPost(PostCreateVM post)
        {
            var posts = new Post
            {
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                Published = post.Published,
                PostedOn = DateTime.Now,
                PostContent = post.PostContent
            };
            await _unitOfWork.PostRepository.Add(posts);
            await _unitOfWork.SaveChanges();
        }

        public async Task DeletePost(int postId)
        {
            _unitOfWork.PostRepository.Delete(postId);
            await _unitOfWork.SaveChanges();
        }

        public async Task EditPost(PostCreateVM post, int id)
        {
            var data = await _unitOfWork.PostRepository.GetById(id);

            if (data is null)
            {
                throw new InvalidOperationException("The Post doesn't exists");
            }

            data.Title = post.Title;
            data.Published = post.Published;

            _unitOfWork.PostRepository.Update(data);
            await _unitOfWork.SaveChanges();
        }

        public async Task<Post> FindPostById(int id)
        {
            return await _unitOfWork.PostRepository.FindPost(id);
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _unitOfWork.PostRepository.GetAllPosts();
        }

        public async Task<Post> GetPostsDetails(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task<Post> GetPostsDetails(int year, int month)
        {
            return await _unitOfWork.PostRepository.FindPost(year, month);
        }

        public async Task<IEnumerable<Post>> GetPublishedPosts()
        {
            return await _unitOfWork.PostRepository.GetPublishedPosts();
        }

        public async Task<IEnumerable<Post>> GetUnpublishedPosts()
        {
            return await _unitOfWork.PostRepository.GetUnpublishedPosts();
        }
    }
}
