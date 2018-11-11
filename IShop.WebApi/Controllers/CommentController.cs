using AutoMapper;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.WebApi.Common.Filters;
using IShop.WebApi.Entities.Comment;
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
        [ModelValidationAsync]
        public async Task<Comment> CreateComment([FromBody] CommentCreateValidatable commentCreate)
        {
            var comment = _mapper.Map<Business.Comment.CommentCreate>(commentCreate);
            var createdComment = await _commentProvider.CreateComment(comment);
            return _mapper.Map<Comment>(createdComment);
        }

        [HttpPut, Route("")]
        public async Task<Comment> UpdateComment([FromBody] Comment commentUpdate)
        {
            var comment = _mapper.Map<Business.Comment.CommentUpdate>(commentUpdate);
            var updatedComment = await _commentProvider.UpdateComment(comment);
            return _mapper.Map<Comment>(updatedComment);
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