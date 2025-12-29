using OnionPronia.Application.DTOs.Products;

namespace OnionPronia.Application.DTOs.Categories
{
    public record GetCategoryDto
    (
        long Id,
        string Name,
        IEnumerable<GetProductInCategoryDto> ProductDtos
        
    );
}
