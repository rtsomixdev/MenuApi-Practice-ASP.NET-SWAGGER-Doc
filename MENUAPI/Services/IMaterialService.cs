using MENUAPI.DTOs;
namespace MENUAPI.Services
{
    public interface IMaterialService
    {
        Task<ResponseMaterialDTO> CreateMaterialAsync(RequestMaterialDTO request);
        Task<IEnumerable<ResponseMaterialDTO>> GetMaterialAsync();
        Task<ResponseMaterialDTO> GetMaterialByIdAsync(int id);
        Task<bool> UpdateMaterialAsync(int id, RequestMaterialDTO request);
        Task<bool> DeleteMaterialAsync(int id);
    }
}
