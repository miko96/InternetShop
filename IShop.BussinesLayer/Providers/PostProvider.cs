using AutoMapper;
using IShop.BussinesLayer.Common.Exceptions;
using IShop.BussinesLayer.Entities.Post;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.DataLayer.ShopDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain = IShop.DataLayer.Entities;

namespace IShop.BussinesLayer.Providers
{
    public class PostProvider : IPostProvider
    {
        private readonly IMapper _mapper;
        private readonly IShopDbContext _shopDbContext;

        public PostProvider(IShopDbContext shopDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _shopDbContext = shopDbContext;
        }

        public async Task<Post> CreatePost(PostCreate postCreate)
        {
            var post = _mapper.Map<Domain.Post>(postCreate);
            _shopDbContext.PostRepository.Add(post);
            await _shopDbContext.SaveAsync();

            return _mapper.Map<Post>(post);
        }

        public async Task<Post> UpdatePost(PostUpdate postUpdate)
        {
            var post = await _shopDbContext.PostRepository.All
                .FirstOrDefaultAsync(p => p.PostId == postUpdate.PostId);

            if (post == null)
                throw new EntityNotFoundException(
                    $"Post {postUpdate.PostId} not found! Can't update the post");

            _mapper.Map(postUpdate, post);
            _shopDbContext.PostRepository.Update(post);
            await _shopDbContext.SaveAsync();

            return _mapper.Map<Post>(post);
        }

        public async Task DeletePost(int postId)
        {
            var post = await _shopDbContext.PostRepository.All
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.PostId == postId);

            if (post == null)
                throw new EntityNotFoundException(
                    $"Post {postId} not found! Can't delete the post");

            _shopDbContext.PostRepository.Remove(post);
            // await _shopUnitOfWork.SaveAsync();
        }

        public async Task<Post> GetPost(int postId)
        {
            var post = await _shopDbContext.PostRepository.All
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.PostId == postId);

            if (post == null)
                throw new EntityNotFoundException(
                    $"Post {postId} not found!");

            return _mapper.Map<Post>(post);
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            var posts = await _shopDbContext.PostRepository.All
                .Include(p => p.Comments)
                .ToListAsync();

            return _mapper.Map<ICollection<Post>>(posts);
        }
    }
}
