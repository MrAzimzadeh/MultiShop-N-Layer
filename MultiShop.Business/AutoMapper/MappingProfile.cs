using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, ProductCategoryDTO>().ReverseMap();
        }
    }
}
