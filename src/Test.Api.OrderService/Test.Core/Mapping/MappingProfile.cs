using AutoMapper;
using Test.Core.DTO;
using Test.Core.Entities;

namespace Test.Core.MappingProfiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderRequest, Order>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

        CreateMap<OrderItemRequest, OrderItem>()
            .ForMember(dest => dest.Order, opt => opt.Ignore())
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));

        CreateMap<Order, OrderResponse>()
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));

        CreateMap<OrderItem, OrderItemResponse>();
    }
}