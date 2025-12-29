using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOs.Sizes;
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
    internal class SizeService:ISizeService
    {
        private readonly ISizeRepository _repository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<GetSizeItemDto>> GetAllAsync(int page, int take)
        {
            var colors = await _repository
                .GetAll(
                 page: page,
                 take: take,
                 includes: nameof(Size.ProductSizes))
                .ToListAsync();
            return _mapper.Map<IReadOnlyList<GetSizeItemDto>>(colors);
        }
    }
}
