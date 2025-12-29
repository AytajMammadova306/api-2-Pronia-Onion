using AutoMapper;
using OnionPronia.Application.DTOs.Categories;
using OnionPronia.Application.DTOs.Products;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.MappingProfiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductInCategoryDto>();
            CreateMap<Product, GetProductItemDto>()
                .ForCtorParam(nameof(GetProductItemDto.CategoryName),
                opt=>opt.MapFrom(p=>p.Category.Name));
        }
    }
}
