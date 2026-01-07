using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionPronia.Application.DTOs.Categories;
using OnionPronia.Application.Interfaces.Repositories;
using OnionPronia.Application.Interfaces.Services;
using OnionPronia.Domain.Entities;


namespace OnionPronia.Persistance.Implementations.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<GetCategoryItemDto>> GetAllAsync(int page, int take)
        {
            var categroeis = await _repository
                .GetAll(
                 page: page,
                 take: take,
                 includes: nameof(Category.Products))
                .ToListAsync();
            return _mapper.Map<IReadOnlyList<GetCategoryItemDto>>(categroeis);

            //return await _repository
            //    .GetAll()
            //    .Select(c => new GetCategoryItemDto(c.Id, c.Name, c.Products.Count()))
            //    .ToListAsync();
        }
        public async Task<GetCategoryDto> GetByIdAsync(int? id)
        {
            Category? category = await _repository.GetByIdAsync(id.Value, nameof(Category.Products));
            if (category == null) throw new Exception("Category Not Found");
            return _mapper.Map<GetCategoryDto>(category);
                
                
                
        }
        public async Task CreateAsync(PostCategoryDto categoryDto)
        {
            if (await _repository.AnyAsync(c=>c.Name==categoryDto.Name))
            {
                throw new Exception($"Category Named:{categoryDto.Name} already exists");
            }
            Category category=_mapper.Map<Category>(categoryDto);
            

            //Category category = new()
            //{
            //    Name = categoryDto.Name,
            //    CreatedAt= DateTime.Now,
            //};
            _repository.Add(category);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, PutCategoryDto categoryDto)
        {
            if (await _repository.AnyAsync(c => c.Name == categoryDto.Name&&c.Id!=id))
            {
                throw new Exception($"Category Named:{categoryDto.Name} already exists");
            }
            Category existed = await _repository.GetByIdAsync(id);


            if (existed is null) throw new Exception("Category not Found");
            existed=_mapper.Map(categoryDto,existed);

            //existed.Name = categoryDto.Name;
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Category? existed = await _repository.GetByIdAsync(id);
            if (existed is null) throw new Exception("Category Not Found");
            _repository.Delete(existed);
            await _repository.SaveChangesAsync();
        }
        public async Task SoftDeleteAsync(int id)
        {
            Category? existed = await _repository.GetByIdAsync(id);
            if (existed is null) throw new Exception("Category Not Found");

            existed.IsDeleted = true;
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }
    }
}
