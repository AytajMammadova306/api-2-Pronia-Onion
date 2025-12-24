using OnionPronia.Application.Interfaces.Repositories;
using OnionPronia.Domain.Entities;
using OnionPronia.Persistance.Contexts;

namespace OnionPronia.Persistance.Implementations.Repositories
{
    internal class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context) { }

    }
}
