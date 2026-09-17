using MENUAPI.DTOs;
using MENUAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MENUAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _service;
        public MenuController(IMenuService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMenuAsync(RequestMenuDTO request)
        {
            try
            {
                var result = await _service.CreateMenuAsync(request);
                return Ok(result);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuAsync()
        {
            var result = await _service.GetMenuAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuByIdAsync(int id)
        {
            try
            {
                var result = await _service.GetMenuByIdAsync(id);
                return Ok(result);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuAsync(int id, RequestMenuDTO request)
        {
            try
            {
                var result = await _service.UpdateMenuAsync(id,request);
                return Ok(result);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuAsync(int id)
        {
            try
            {
                var result = await _service.DeleteMenuAsync(id);
                return Ok(result);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
