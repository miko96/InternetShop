using AutoMapper;
using IShop.BussinesLayer.Entities;
using IShop.BussinesLayer.Providers.Interfaces;
using IShop.DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain = IShop.DataLayer.Entities;

namespace IShop.BussinesLayer.Providers
{
    public class CommentProvider : ICommentProvider
    {
        private readonly IMapper _mapper;
        private readonly IShopUnitOfWork _shopUnitOfWork;

        public CommentProvider(IShopUnitOfWork shopUnitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _shopUnitOfWork = shopUnitOfWork;
        }

        public async Task CreateComment(Comment comment)
        {
            var alreadyExists = _shopUnitOfWork.Comments.All
              .Any(c => c.CommentId == comment.CommentId);

            if (alreadyExists)
            {
                //!!!
                throw new Exception();
            }

            var domainComment = _mapper.Map<Domain.Comment>(comment);
            _shopUnitOfWork.Comments.Add(domainComment);

            await _shopUnitOfWork.SaveAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            var alreadyExists = _shopUnitOfWork.Comments.All
              .Any(c => c.CommentId == comment.CommentId);
            
            if(!alreadyExists)
            {
                //!!!
                throw new Exception();
            }

            var domainComment = _mapper.Map<Domain.Comment>(comment);
            _shopUnitOfWork.Comments.Update(domainComment);

            await _shopUnitOfWork.SaveAsync();
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _shopUnitOfWork.Comments.All
              .FirstOrDefaultAsync(c => c.CommentId == commentId);

            if (comment == null)
            {
                //!!!
                throw new Exception();
            }

            _shopUnitOfWork.Comments.Remove(comment);
            //await _shopUnitOfWork.SaveAsync();
        }


        public async Task<Comment> GetComment(int commentId)
        {
            var comment = await _shopUnitOfWork.Comments.All
                .FirstOrDefaultAsync(c => c.CommentId == commentId);

            if (comment == null)
            {
                //!!!
                throw new Exception();
            }

            return _mapper.Map<Comment>(comment);
        }

        public async Task<ICollection<Comment>> GetAllComments()
        {
            var comments = await _shopUnitOfWork.Comments.All
                .ToListAsync();

            return _mapper.Map<ICollection<Comment>>(comments);
        }

        public async Task<ICollection<Comment>> GetPostComments(int postId)
        {
            var postComments = await _shopUnitOfWork.Comments.All
                .Where(c => c.PostId == postId)
                .ToListAsync();

            return _mapper.Map<ICollection<Comment>>(postComments);
        }
    }
}
