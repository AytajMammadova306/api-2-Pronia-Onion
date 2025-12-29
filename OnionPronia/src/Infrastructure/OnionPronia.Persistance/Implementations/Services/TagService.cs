using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOs.Tags;
using OnionPronia.Application.Interfaces.Repositories;
using OnionPronia.Application.Interfaces.Services;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Persistance.Implementations.Services
{
    internal class TagService:ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<GetTagItemDto>> GetAllAsync(int page, int take)
        {
            var tags = await _repository
                .GetAll(
                 page: page,
                 take: take,
                 includes: nameof(Tag.ProductTags))
                .ToListAsync();
            return _mapper.Map<IReadOnlyList<GetTagItemDto>>(tags);
        }
    }
}
