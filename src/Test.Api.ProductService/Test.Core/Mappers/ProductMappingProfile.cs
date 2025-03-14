using AutoMapper;
using Test.Core.DTO;
using Test.Core.Entities;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<Product, ProductResponse>();
    }
}