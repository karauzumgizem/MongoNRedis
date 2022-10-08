using FarmasiCase.Entities.Concrete;
using FarmasiCase.Entities.Dto;
using AutoMapper;

namespace FarmasiCase.Services.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Products>();
            CreateMap<Products, ProductDto>();
        }
    }
}
