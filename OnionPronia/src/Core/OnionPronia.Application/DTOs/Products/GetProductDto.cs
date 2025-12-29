using OnionPronia.Application.DTOs.Categories;
using OnionPronia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.DTOs.Products
{
    public record GetProductDto(
        int Id,
        string Name,
        decimal Price,
        string SKU,
        string Color,
        string Description,
        string Tag,
        string Size,
        GetCategoryInProductDto CategoryDto,
        ICollection<Tag> Tags);
}
