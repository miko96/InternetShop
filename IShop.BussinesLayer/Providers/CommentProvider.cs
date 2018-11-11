using AutoMapper;
using IShop.BussinesLayer.Entities.Comment;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.DataLayer.ShopDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IShop.BussinesLayer.Common.Exceptions;
using Domain = IShop.DataLayer.Entities;

namespace IShop.BussinesLayer.Providers
{
    public class CommentProvider : ICommentProvider
    {
        private readonly IMapper _mapper;
        private readonly IShopDbContext _shopDbContext;

        public CommentProvider(IShopDbContext shopDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _shopDbContext = shopDbContext;
        }

        public async Task<Comment> CreateComment(CommentCreate commentCreate)
        {
            var comment = _mapper.Map<Domain.Comment>(commentCreate);
            _shopDbContext.CommentRepository.Add(comment);
            await _shopDbContext.SaveAsync();

            return _mapper.Map<Comment>(comment);
        }

        public async Task<Comment> UpdateComment(CommentUpdate commentUpdate)
        {
            var comment = await _shopDbContext.CommentRepository.All
                .FirstOrDefaultAsync(c => c.CommentId == commentUpdate.CommentId);

            if (comment == null)
                throw new EntityNotFoundException(
                    $"Comment {commentUpdate.CommentId} not found! Can't update the comment");

            _mapper.Map(commentUpdate, comment);
            _shopDbContext.CommentRepository.Update(comment);
            await _shopDbContext.SaveAsync();

            return _mapper.Map<Comment>(comment);
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _shopDbContext.CommentRepository.All
              .FirstOrDefaultAsync(c => c.CommentId == commentId);

            if (comment == null)
                throw new EntityNotFoundException(
                    $"Comment {commentId} not found! Can't delete the comment");

            _shopDbContext.CommentRepository.Remove(comment);
            // await _shopUnitOfWork.SaveAsync();
        }


        public async Task<Comment> GetComment(int commentId)
        {
            var comment = await _shopDbContext.CommentRepository.All
                .FirstOrDefaultAsync(c => c.CommentId == commentId);

            if (comment == null)
                throw new EntityNotFoundException($"Comment {commentId} not found!");

            return _mapper.Map<Comment>(comment);
        }

        public async Task<ICollection<Comment>> GetAllComments()
        {
            var comments = await _shopDbContext.CommentRepository.All
                .ToListAsync();

            return _mapper.Map<ICollection<Comment>>(comments);
        }

        public async Task<ICollection<Comment>> GetPostComments(int postId)
        {
            var postComments = await _shopDbContext.CommentRepository.All
                .Where(c => c.PostId == postId)
                .ToListAsync();

            return _mapper.Map<ICollection<Comment>>(postComments);
        }
    }
}
