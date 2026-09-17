using Azure.Core;
using MENUAPI.DTOs;
using MENUAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MENUAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;
        public MaterialController(IMaterialService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaterialAsync(RequestMaterialDTO request)
        {
            try
            {
                var result = await _service.CreateMaterialAsync(request);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialAsync()
        {
            var result = await _service.GetMaterialAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterialByIdAsync(int id)
        {
            try
            {
                var result = await _service.GetMaterialByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaterialAsync(int id, RequestMaterialDTO request)
        {
            try
            {
                var result = await _service.UpdateMaterialAsync(id, request);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterialAsync(int id)
        {
            try
            {
                var result = await _service.DeleteMaterialAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
