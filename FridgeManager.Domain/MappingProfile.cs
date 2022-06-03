using AutoMapper;
using FridgeManager.Domain.DTO.Fridge;
using FridgeManager.Domain.DTO.FridgeModel;
using FridgeManager.Domain.DTO.FridgeProduct;
using FridgeManager.Domain.DTO.Product;
using FridgeManager.Domain.Models;
using FridgeManager.Domain.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>()
                .ForMember(f => f.FullModelName,
                    opt => opt.MapFrom(x => string.Join(' ', x.Name, x.Model.Name)));

            CreateMap<FridgeModel, FridgeModelDto>();

            //CreateMap<User, UserDto>();
            CreateMap<RegisterUser, User>();
            CreateMap<LoginUser, User>();

            CreateMap<FridgeProduct, FridgeProductDto>()
                .ForMember(fp => fp.Firdge, opt => opt.MapFrom(x => $"{x.Fridge.Name} ({x.Fridge.OwnerName})"))
                .ForMember(fp => fp.Product, opt => opt.MapFrom(x => x.Product.Name));

            CreateMap<FridgeProduct, FridgeProductTotalDto>()
                .ForMember(fp => fp.Fridge, opt => opt.MapFrom(x => $"{x.Fridge.Name} ({x.Fridge.OwnerName})"))
                .ForMember(fp => fp.Product, opt => opt.MapFrom(x => x.Product.Name))
                .ForMember(fp => fp.TotalQuantity, opt => opt.MapFrom(x => x.Quantity));

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
