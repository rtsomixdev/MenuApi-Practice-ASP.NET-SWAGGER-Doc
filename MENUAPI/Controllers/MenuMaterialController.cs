using MENUAPI.DTOs;
using MENUAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.NativeInterop;

namespace MENUAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuMaterialController : ControllerBase
    {
        private readonly IMenuMaterialService _service;
        public MenuMaterialController(IMenuMaterialService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> AddMenuMaterial(RequestMenuMaterialDTO request)
        {
            try
            {
                var result = await _service.AddMenuMaterialAsync(request);
                return Ok(new { message = "เพิ่มวัตถุดิบสำเร็จ", totalprice = result });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenuMaterial(RequestMenuMaterialDTO request)
        {
            try
            {
                var result = await _service.UpdateMenuMaterialAsync(request);
                return Ok(new { message = "อัพเดทวัตถุดิบสำเร็จ", totalprice = result });
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuMaterialByIdAsync(int id)
        {
            try
            {
                var result = await _service.GetMenuMaterialByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{menuId}/{materialId}")]
        public async Task<IActionResult> RemoveMenuMaterialAsync(int menuId,int materialId)
        {
            try
            {
                var result = await _service.RemoveMenuMaterialAsync(menuId, materialId);
                return Ok(new { message = "ลบวัตถุดิบสำเร็จ", totalPrice = result });
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
