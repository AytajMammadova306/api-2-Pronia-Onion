using OnionPronia.Application.DTOs.Sizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Interfaces.Services
{
    public interface ISizeService
    {
        Task<IReadOnlyList<GetSizeItemDto>> GetAllAsync(int page, int take);
    }
}
