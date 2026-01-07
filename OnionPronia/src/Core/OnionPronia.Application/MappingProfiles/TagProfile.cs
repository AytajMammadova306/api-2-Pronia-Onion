using AutoMapper;
using OnionPronia.Application.DTOs.Tags;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.MappingProfiles
{
    internal class TagProfile:Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, GetTagItemDto>()
                .ForCtorParam(nameof(GetTagItemDto.ProductCount),
                opt => opt.MapFrom(t => t.ProductTags.Count));
            CreateMap<Tag, GetTagInProductDto>();
        }
    }
}
