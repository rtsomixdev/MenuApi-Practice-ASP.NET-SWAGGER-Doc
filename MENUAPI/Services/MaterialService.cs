using MENUAPI.DTOs;
using MENUAPI.Data;
using MENUAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MENUAPI.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly Context _db;
        public MaterialService(Context db)
        {
            _db = db;
        }

        /*CREATE*/
        public async Task<ResponseMaterialDTO> CreateMaterialAsync(RequestMaterialDTO request)
        {
            var material = new Material
            {
                MaterialName = request.MaterialName,
                Quantity = request.Quantity,
                Unit = request.Unit,
                UnitPrice = request.UnitPrice,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _db.Materials.Add(material);
            await _db.SaveChangesAsync();
            return new ResponseMaterialDTO
            {
                MaterialId = material.MaterialId,
                MaterialName = material.MaterialName,
                Quantity = material.Quantity,
                Unit = material.Unit,
                UnitPrice = material.UnitPrice,
                CreatedAt = material.CreatedAt,
                UpdatedAt = material.UpdatedAt
            };
        }

        /*GET*/
        public async Task<IEnumerable<ResponseMaterialDTO>> GetMaterialAsync()
        {
            return await _db.Materials.AsNoTracking().Select(m => new ResponseMaterialDTO
            {
                MaterialId = m.MaterialId,
                MaterialName = m.MaterialName,
                Quantity = m.Quantity,
                Unit = m.Unit,
                UnitPrice = m.UnitPrice,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt,
            }).ToListAsync();
        }

        /*GET BY ID*/
        public async Task<ResponseMaterialDTO> GetMaterialByIdAsync(int id)
        {
            var material = await _db.Materials.AsNoTracking().FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null) throw new KeyNotFoundException($"ไม่พบ {id}");
            return new ResponseMaterialDTO
            {
                MaterialId = material.MaterialId,
                MaterialName = material.MaterialName,
                Quantity = material.Quantity,
                Unit = material.Unit,
                UnitPrice = material.UnitPrice,
                CreatedAt = material.CreatedAt,
                UpdatedAt = material.UpdatedAt,
            };
        }

        /*UPDATE*/
        public async Task<bool> UpdateMaterialAsync(int id, RequestMaterialDTO request)
        {
            var updatematerial = await _db.Materials.FirstOrDefaultAsync(m => m.MaterialId == id);
            if (updatematerial == null) throw new KeyNotFoundException($"ไม่พบ {id}");

            updatematerial.MaterialName = request.MaterialName;
            updatematerial.Quantity = request.Quantity;
            updatematerial.Unit = request.Unit;
            updatematerial.UnitPrice = request.UnitPrice;
            updatematerial.UpdatedAt = DateTime.Now;

            await _db.SaveChangesAsync();
            return true;
        }

        /*DELETE*/
        public async Task<bool> DeleteMaterialAsync(int id)
        {
            var deletematerial = await _db.Materials.FirstOrDefaultAsync(m => m.MaterialId == id);
            if (deletematerial == null) throw new KeyNotFoundException($"ไม่พบ {id}");

            _db.Materials.Remove(deletematerial);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
