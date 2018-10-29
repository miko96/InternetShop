using AutoMapper;
using IShop.BussinesLayer.Entities;
using Domain = IShop.DataLayer.Entities;

namespace IShop.BussinesLayer.Mapping
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Domain.Comment, Comment>()
                .ReverseMap();

            CreateMap<Domain.Post, Post>()
                .ReverseMap();

            CreateMap<Domain.ProductItem, ProductItem>();
        }  
    }
}
