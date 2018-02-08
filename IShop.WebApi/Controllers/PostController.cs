using AutoMapper;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business = IShop.BussinesLayer.Entities;

namespace IShop.WebApi.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostProvider _postProvider;
        private readonly ICommentProvider _commentProvider;

        public PostController(
             IMapper mapper,
            IPostProvider postProvider,
            ICommentProvider commentProvider)
        {
            _mapper = mapper;
            _postProvider = postProvider;
            _commentProvider = commentProvider;
        }

        [HttpPost, Route("")]
        public async Task CreatPost([FromBody] Post post)
        {
            var bePost = _mapper.Map<Business.Post>(post);

            await _postProvider.CreatePost(bePost);
        }

        [HttpPut, Route("")]
        public async Task UpdatePost([FromBody] Post post)
        {
            var bePost = _mapper.Map<Business.Post>(post);

            await _postProvider.UpdatePost(bePost);
        }

        [HttpDelete, Route("{postId}")]
        public async Task DeletePost(int postId)
        {
            await _postProvider.DeletePost(postId);
        }

        [HttpGet, Route("{postId}")]
        public async Task<Post> GetPost(int postId)
        {
            var post = await _postProvider.GetPost(postId);

            return _mapper.Map<Post>(post);
        }

        [HttpGet, Route("all")]
        public async Task<ICollection<Post>> AllPosts()
        {
            var posts = await _postProvider.GetAllPosts();

            return _mapper.Map<ICollection<Post>>(posts);
        }

        [HttpGet, Route("{postId}/comments")]
        public async Task<ICollection<Comment>> PostComments(int postId)
        {
            var comments = await _commentProvider.GetPostComments(postId);

            return _mapper.Map<ICollection<Comment>>(comments);
        }
    }
}