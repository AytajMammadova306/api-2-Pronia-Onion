using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionPronia.Application.Interfaces.Services;

namespace OnionPronia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _service;

        public TagsController(ITagService service)
        {
            _service = service;
        }
        public async Task<IActionResult> GetAsync(int page = 0, int take = 0)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
    }
}
