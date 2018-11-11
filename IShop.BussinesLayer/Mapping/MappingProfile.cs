using AutoMapper;
using IShop.BussinesLayer.Entities.Comment;
using IShop.BussinesLayer.Entities.Post;
using Domain = IShop.DataLayer.Entities;

namespace IShop.BussinesLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CommentCreate, Domain.Comment>();
            CreateMap<CommentUpdate, Domain.Comment>();
            CreateMap<Domain.Comment, Comment>();

            CreateMap<PostCreate, Domain.Post>();
            CreateMap<PostUpdate, Domain.Post>();
            CreateMap<Domain.Post, Post>();
        }
    }
}
