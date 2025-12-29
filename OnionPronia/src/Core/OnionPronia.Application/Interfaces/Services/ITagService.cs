using OnionPronia.Application.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionPronia.Application.Interfaces.Services
{
    public interface ITagService
    {
        Task<IReadOnlyList<GetTagItemDto>> GetAllAsync(int page, int take);
    }
}
