namespace OnionPronia.Application.DTOs.Categories
{
    public record GetCategoryItemDto(
        long Id,
        string Name,
        int ProductCount
        );
}
