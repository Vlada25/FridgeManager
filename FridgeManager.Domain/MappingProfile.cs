using AutoMapper;
using FridgeManager.DTO.Fridge;
using FridgeManager.DTO.FridgeModel;
using FridgeManager.DTO.FridgeProduct;
using FridgeManager.DTO.Product;
using FridgeManager.Domain.Models;
using FridgeManager.DTO.User;

namespace FridgeManager.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>()
                .ForMember(f => f.FullModelName,
                    opt => opt.MapFrom(x => string.Join(' ', x.Name, x.Model.Name)));

            CreateMap<User, UserDto>();
            CreateMap<RegisterUser, User>();
            CreateMap<LoginUser, User>();

            CreateMap<FridgeProduct, FridgeProductDto>()
                .ForMember(fp => fp.Fridge, opt => opt.MapFrom(x => $"{x.Fridge.Name} ({x.Fridge.OwnerName})"))
                .ForMember(fp => fp.Product, opt => opt.MapFrom(x => x.Product.Name));

            CreateMap<FridgeForCreationDto, Fridge>();
            CreateMap<FridgeModelForCreationDto, FridgeModel>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<FridgeProductForCreationDto, FridgeProduct>();

            CreateMap<FridgeForUpdateDto, Fridge>();
            CreateMap<FridgeProductForUpdateDto, FridgeProduct>();
            CreateMap<FridgeModelForUpdateDto, FridgeModel>();
            CreateMap<ProductForUpdateDto, Product>();
        }
    }
}
