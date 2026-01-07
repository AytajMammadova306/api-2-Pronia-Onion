using AutoMapper;
using OnionPronia.Application.DTOs.Colors;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.MappingProfiles
{
    internal class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, GetColorItemDto>()
                .ForCtorParam(nameof(GetColorItemDto.ProductCount),
                opt => opt.MapFrom(c => c.ProductColors.Count));
            CreateMap<Color, GetColorInProductDto>();
        }
    }
}
