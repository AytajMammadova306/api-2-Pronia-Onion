using OnionPronia.Application.DTOs.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Interfaces.Services
{
    public interface IColorService
    {
        Task<IReadOnlyList<GetColorItemDto>> GetAllAsync(int page, int take);
    }
}
