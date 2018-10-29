using AutoMapper;
using IShop.WebApi.Entities;
using Business = IShop.BussinesLayer.Entities;

namespace IShop.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                CreateMap<Business.Comment, Comment>()
                    .ReverseMap();

                CreateMap<Business.Post, Post>()
                    .ReverseMap();
        }
    }
}