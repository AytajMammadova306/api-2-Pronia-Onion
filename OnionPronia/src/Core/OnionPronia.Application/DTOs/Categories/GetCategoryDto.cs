namespace OnionPronia.Application.DTOs.Categories
{
    public record GetCategoryDto
    (
        int Id,
        string Name,
        IEnumerable<GetProductInCategoryDto> ProductDtos
        
    );
}
