using AutoMapper;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business = IShop.BussinesLayer.Entities;

namespace IShop.WebApi.Controllers
{
    [Route("api/comments")]
    public class CommentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommentProvider _commentProvider;

        public CommentController(ICommentProvider commentProvider, IMapper mapper)
        {
            _mapper = mapper;
            _commentProvider = commentProvider;
        }

        [HttpPost, Route("")]
        public async Task CreateComment([FromBody] Comment comment)
        {
            var beCommnet = _mapper.Map<Business.Comment>(comment);

            await _commentProvider.CreateComment(beCommnet);
        }

        [HttpPut, Route("")]
        public async Task UpdateComment([FromBody] Comment comment)
        {
            var beCommnet = _mapper.Map<Business.Comment>(comment);

            await _commentProvider.UpdateComment(beCommnet);
        }

        [HttpDelete, Route("{commentId}")]
        public async Task DeleteComment(int commentId)
        {
            await _commentProvider.DeleteComment(commentId);
        }

        [HttpGet, Route("{commentId}")]
        public async Task<Comment> GetComment(int commentId)
        {
            var comment = await _commentProvider.GetComment(commentId);

            return _mapper.Map<Comment>(comment);
        }

        [HttpGet, Route("all")]
        public async Task<ICollection<Comment>> AllComments()
        {
            var comments = await _commentProvider.GetAllComments();

            return _mapper.Map<ICollection<Comment>>(comments);
        }
    }
}