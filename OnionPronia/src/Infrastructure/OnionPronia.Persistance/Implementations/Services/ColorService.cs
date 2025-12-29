using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOs.Colors;
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
    internal class ColorService:IColorService
    {
        private readonly IColorRepository _repository;
        private readonly IMapper _mapper;

        public ColorService(IColorRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<GetColorItemDto>> GetAllAsync(int page, int take)
        {
            var colors = await _repository
                .GetAll(
                 page: page,
                 take: take,
                 includes: nameof(Color.ProductColors))
                .ToListAsync();
            return _mapper.Map<IReadOnlyList<GetColorItemDto>>(colors);
        }
    }
}
