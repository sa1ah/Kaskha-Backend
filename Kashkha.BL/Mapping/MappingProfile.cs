using AutoMapper;
using Kashkha.DAL.Models;
using Kashkha.BL.DTOs;
using Kashkha.DAL;
using Kashkha.BL.DTOs.CartDTOs;
using Kashkha.BL.DTOs.FavoriteDTOs;

namespace Kashkha.BL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Favorite, FavoriteDTO>().ReverseMap();
           // CreateMap<CreateFavoriteDTO, Favorite>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<CartItem, CartItemDTO>().ReverseMap();
            CreateMap<Shop, ShopOwnerDTO>().ReverseMap();
            CreateMap<Favorite, GetFavoriteDto>().ForMember(
  d => d.ProductId, opt => opt.MapFrom(src => src.Product.Id))
    .ForMember(d => d.ProductName, opt => opt.MapFrom(src => src.Product.Name))
    .ForMember(d => d.ProductImage, opt => opt.MapFrom(src => src.Product.PictureUrl))
    .ForMember(d => d.quantity, opt => opt.MapFrom(src => src.Product.Quantity))
    .ForMember(d => d.price, opt => opt.MapFrom(src => src.Product.Price))
    .ForMember(d => d.categoryName, opt => opt.MapFrom(src => src.Product.Category.Name))
    .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Product.Description))
    .ForMember(d => d.price, opt => opt.MapFrom(src => src.Product.Price))
    .ForMember(d => d.shopId, opt => opt.MapFrom(src => src.Product.ShopId))
    .ForMember(d => d.shopName, opt => opt.MapFrom(src => src.Product.Shop.ShopName))
    .ForMember(d => d.shopImage, opt => opt.MapFrom(src => src.Product.Shop.ProfilePicture))
    .ForMember(d => d.price, opt => opt.MapFrom(src => src.Product.Price))
    .ForMember(d => d.FavoriteId, opt => opt.MapFrom(src => src.Id))
    .ForMember(d => d.ProductId, opt => opt.MapFrom(src => src.Product.Id));
        }

      
    }

   
}