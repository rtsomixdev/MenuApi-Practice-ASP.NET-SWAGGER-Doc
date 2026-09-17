using MENUAPI.Data;
using MENUAPI.DTOs;
using MENUAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MENUAPI.Services
{
    public class MenuMaterialService : IMenuMaterialService
    {
        private readonly Context _db;
        public MenuMaterialService(Context db)
        {
            _db = db;
        }
        
        /*CALCULATE*/
        private async Task<decimal> TotalPriceAsync(int menuId)
        {
            var totalprice = await _db.MenuMaterials
                .Where(mm => mm.MenuId == menuId)
                .SumAsync(mm => mm.Quantity * mm.Material.UnitPrice);
            var menu = await _db.Menus.FirstOrDefaultAsync(m => m.MenuId == menuId);
            if (menu == null) throw new KeyNotFoundException($"ไม่พบ {menuId}");

            menu.TotalPrice = totalprice;
            menu.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();

            return totalprice;
        }

        /*ADD*/
        public async Task<decimal> AddMenuMaterialAsync(RequestMenuMaterialDTO request)
        {
            var menu = await _db.Menus.AnyAsync(m => m.MenuId == request.MenuId);
            if (!menu) throw new KeyNotFoundException($"ไม่พบ {request.MenuId}");
            var material = await _db.Materials.AnyAsync(m => m.MaterialId == request.MaterialId);
            if (!material) throw new KeyNotFoundException($"ไม่พบ {request.MaterialId}");
            var existing = await _db.MenuMaterials.AnyAsync(mm => mm.MenuId == request.MenuId && mm.MaterialId == request.MaterialId);
            if (existing) throw new InvalidOperationException("มีวัตถุดิบอยู่แล้ว");

            var menumaterial = new MenuMaterial
            {
                MenuId = request.MenuId,
                MaterialId = request.MaterialId,
                Quantity = request.Quantity
            };
            _db.MenuMaterials.Add(menumaterial);
            await _db.SaveChangesAsync();

            return await TotalPriceAsync(request.MenuId);
        }

        /*UPDATE*/
        public async Task<decimal> UpdateMenuMaterialAsync(RequestMenuMaterialDTO request)
        {
            var updatemenumaterial = await _db.MenuMaterials.FirstOrDefaultAsync(mm => mm.MenuId == request.MenuId && mm.MaterialId == request.MaterialId);
            if (updatemenumaterial == null) throw new KeyNotFoundException($"ไม่พบ {request.MaterialId} ในเมนู {request.MenuId}");

            updatemenumaterial.Quantity = request.Quantity;
            updatemenumaterial.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();

            return await TotalPriceAsync(request.MenuId);
        }

        /*REMOVE*/
        public async Task<decimal> RemoveMenuMaterialAsync(int menuId,int materialId)
        {
            var deletemenumaterial = await _db.MenuMaterials.FirstOrDefaultAsync(mm => mm.MenuId == menuId && mm.MaterialId == materialId);
            if (deletemenumaterial == null) throw new KeyNotFoundException($"ไม่พบ {materialId} ในเมนู {menuId}");
            _db.MenuMaterials.Remove(deletemenumaterial);
            await _db.SaveChangesAsync();
            
            return await TotalPriceAsync(menuId);
        }

        /*GET BY ID*/
        public async Task<IEnumerable<ResponseMenuMaterialDTO>> GetMenuMaterialByIdAsync(int menuId)
        {
            var menu = await _db.Menus.AnyAsync(m => m.MenuId == menuId);
            if (!menu) throw new KeyNotFoundException($"ไม่พบ {menuId}");
            return await _db.MenuMaterials
                .AsNoTracking()
                .Where(mm => mm.MenuId == menuId)
                .Select(mm => new ResponseMenuMaterialDTO
                {
                    MenuId = mm.MenuId,
                    MaterialId = mm.MaterialId,
                    MenuName = mm.Menu.MenuName,
                    MaterialName = mm.Material.MaterialName,
                    Quantity = mm.Quantity,
                    Unit = mm.Material.Unit,
                    UnitPrice = mm.Material.UnitPrice,
                    TotalPrice = mm.Quantity * mm.Material.UnitPrice,
                    CreatedAt = mm.CreatedAt,
                    UpdatedAt = mm.UpdatedAt,
                }).ToListAsync();
        }
    }
}
