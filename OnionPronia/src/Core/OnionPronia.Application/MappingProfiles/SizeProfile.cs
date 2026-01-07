using AutoMapper;
using OnionPronia.Application.DTOs.Sizes;
using OnionPronia.Application.DTOs.Tags;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.MappingProfiles
{
    internal class SizeProfile:Profile
    {
        public SizeProfile()
        {
            CreateMap<Size, GetSizeItemDto>()
                .ForCtorParam(nameof(GetSizeItemDto.ProductCount),
                opt => opt.MapFrom(s => s.ProductSizes.Count));
            CreateMap<Size, GetSizeInProductDtp>();
        }
    }
}
