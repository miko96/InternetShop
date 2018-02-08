using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IShop.BussinesLayer.Entities;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.DataLayer;
using Microsoft.EntityFrameworkCore;
using Domain = IShop.DataLayer.Entities;

namespace IShop.BussinesLayer.Providers
{
    public class PostProvider : IPostProvider
    {
        private readonly IMapper _mapper;
        private readonly IShopUnitOfWork _shopUnitOfWork;

        public PostProvider(IShopUnitOfWork shopUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _shopUnitOfWork = shopUnitOfWork;
        }

        public async Task CreatePost(Post post)
        {
            var alreadyExists = _shopUnitOfWork.Posts.All
                .Any(p => p.PostId == post.PostId);

            if (alreadyExists)
            {
                throw new Exception();
            }

            var domainPost = _mapper.Map<Domain.Post>(post);
            _shopUnitOfWork.Posts.Add(domainPost);

            await _shopUnitOfWork.SaveAsync();
        }

        public async Task UpdatePost(Post post)
        {
            var alreadyExists = _shopUnitOfWork.Posts.All
                .Any(p => p.PostId == post.PostId);

            if (alreadyExists)
            {
                throw new Exception();
            }

            var domainPost = _mapper.Map<Domain.Post>(post);
            _shopUnitOfWork.Posts.Update(domainPost);

            await _shopUnitOfWork.SaveAsync();
        }

        public async Task DeletePost(int postId)
        {
            var post = await _shopUnitOfWork.Posts.All
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.PostId == postId);

            if (post == null)
            {
                throw new Exception();
            }

            _shopUnitOfWork.Posts.Remove(post);
            //await _shopUnitOfWork.SaveAsync();
        }

        public async Task<Post> GetPost(int postId)
        {
            var post = await _shopUnitOfWork.Posts.All
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.PostId == postId);

            if (post == null)
            {
                throw new Exception();
            }

            return _mapper.Map<Post>(post);
        }

        public async Task<ICollection<Post>> GetAllPosts()
        {
            var posts = await _shopUnitOfWork.Posts.All
                .Include(p => p.Comments)
                .ToListAsync();

            return _mapper.Map<ICollection<Post>>(posts);
        }
    }
}
