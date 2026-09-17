using MENUAPI.DTOs;

namespace MENUAPI.Services
{
    public interface IMenuMaterialService
    {
        Task<decimal> AddMenuMaterialAsync(RequestMenuMaterialDTO request);
        Task<decimal> UpdateMenuMaterialAsync(RequestMenuMaterialDTO request);
        Task<decimal> RemoveMenuMaterialAsync(int menuId, int materialId);
        Task<IEnumerable<ResponseMenuMaterialDTO>> GetMenuMaterialByIdAsync(int menuId);
    }
}
