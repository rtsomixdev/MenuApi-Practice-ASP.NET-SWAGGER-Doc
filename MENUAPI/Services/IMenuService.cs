using MENUAPI.DTOs;

namespace MENUAPI.Services
{
    public interface IMenuService
    {
        Task<ResponseMenuDTO> CreateMenuAsync(RequestMenuDTO request);
        Task<IEnumerable<ResponseMenuDTO>> GetMenuAsync();
        Task<ResponseMenuDTO> GetMenuByIdAsync(int id);
        Task<bool> UpdateMenuAsync(int id, RequestMenuDTO request);
        Task<bool> DeleteMenuAsync(int id);
    }
}
