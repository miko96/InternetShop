using AutoMapper;
using IShop.WebApi.Entities.Comment;
using IShop.WebApi.Entities.Post;
using Business = IShop.BussinesLayer.Entities;

namespace IShop.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CommentCreate, Business.Comment.CommentCreate>();
            CreateMap<CommentUpdate, Business.Comment.CommentUpdate>();
            CreateMap<Business.Comment.Comment, Comment>();

            CreateMap<PostCreate, Business.Post.PostCreate>();
            CreateMap<PostUpdate, Business.Post.PostUpdate>();
            CreateMap<Business.Post.Post, Post>();
        }
    }
}