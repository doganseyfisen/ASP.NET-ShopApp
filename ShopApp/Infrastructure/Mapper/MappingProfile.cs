using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace ShopApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            // When it comes to update, this source-target relation becomes also t-s
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
        }
    }
}