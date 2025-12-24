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

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyList<GetCategoryItemDto>> GetAllAsync(int page, int take)
        {
            return await _repository
                .GetAll()
                .Select(c => new GetCategoryItemDto(c.Id, c.Name, c.Products.Count()))
                .ToListAsync();
        }
        public async Task<GetCategoryDto> GetByIdAsync(int? id)
        {
            Category? category = await _repository.GetByIdAsync(id.Value, nameof(Category.Products));
            if (category == null) throw new Exception("Category Not Found");
            return new GetCategoryDto(
                category.Id,
                category.Name,
                ProductDtos: category.Products
                    .Select(p => new GetProductInCategoryDto(p.Id, p.Name, p.Price)));
        }
        public async Task CreateAsync(PostCategoryDto categoryDto)
        {
            if (await _repository.AnyAsync(c=>c.Name==categoryDto.Name))
            {
                throw new Exception($"Category Named:{categoryDto.Name} already exists");
            }

            Category category = new()
            {
                Name = categoryDto.Name,
                CreatedAt= DateTime.Now,
            };
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

            existed.Name = categoryDto.Name;
            existed.Updated= DateTime.Now;
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
    }
}
