using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOs.Products;
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
    internal class ProductService:IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public ProductService(
            IProductRepository repository,
            IMapper mapper)
        {
            _mapper = mapper;
            _repository=repository; 
        }
        public async Task<IReadOnlyList<GetProductItemDto>> GetAllAsync(int page, int take)
        {
            IReadOnlyList<Product> products=await _repository.GetAll(
                page: page,
                take: take,
                includes:nameof(Product.Category)).ToListAsync();
            return _mapper.Map<IReadOnlyList<GetProductItemDto>>(products);
        }
        public async Task<GetProductDto> GetByIdAsync(long id)
        {
            Product product=await _repository.GetByIdAsync(id,"ProductTags.Tag",nameof(Product.Category));
            if (product is null) throw new Exception("Entity Not Found");
            return _mapper.Map<GetProductDto>(product);
        }
    }
}
