using MENUAPI.Data;
using MENUAPI.DTOs;
using MENUAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MENUAPI.Services
{
    public class MenuService : IMenuService
    {
        private readonly Context _db;
        public MenuService(Context db)
        {
            _db = db;
        }

        /*CREATE*/
        public async Task<ResponseMenuDTO> CreateMenuAsync(RequestMenuDTO request)
        {
            var menu = new Menu
            {
                MenuName = request.MenuName,
                Price = request.Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            _db.Menus.Add(menu);
            await _db.SaveChangesAsync();
            return new ResponseMenuDTO
            {
                MenuId = menu.MenuId,
                MenuName = menu.MenuName,
                Price = menu.Price,
                TotalPrice = menu.TotalPrice,
                CreatedAt = menu.CreatedAt,
                UpdatedAt = menu.UpdatedAt,
            };
        }

        /*GET*/
        public async Task<IEnumerable<ResponseMenuDTO>> GetMenuAsync()
        {
            return await _db.Menus.AsNoTracking().Select(m => new ResponseMenuDTO
            {
                MenuId = m.MenuId,
                MenuName = m.MenuName,
                Price = m.Price,
                TotalPrice = m.TotalPrice,
                CreatedAt = m.CreatedAt,
                UpdatedAt = m.UpdatedAt,
            }).ToListAsync();
        }

        /*GET BY ID*/
        public async Task<ResponseMenuDTO> GetMenuByIdAsync(int id)
        {
            var menu = await _db.Menus.AsNoTracking().FirstOrDefaultAsync(m => m.MenuId == id);
            if (menu == null) throw new KeyNotFoundException($"ไม่พบ {id}");
            return new ResponseMenuDTO
            {
                MenuId = menu.MenuId,
                MenuName = menu.MenuName,
                Price = menu.Price,
                TotalPrice = menu.TotalPrice,
                CreatedAt = menu.CreatedAt,
                UpdatedAt = menu.UpdatedAt,
            };
        }

        /*UPDATE*/
        public async Task<bool> UpdateMenuAsync(int id, RequestMenuDTO request)
        {
            var updatemenu = await _db.Menus.FirstOrDefaultAsync(m => m.MenuId == id);
            if (updatemenu == null) throw new KeyNotFoundException($"ไม่พบ {id}");

            updatemenu.MenuName = request.MenuName;
            updatemenu.Price = request.Price;
            updatemenu.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();
            return true;
        }

        /*DELETE*/
        public async Task<bool> DeleteMenuAsync(int id)
        {
            var deletemenu = await _db.Menus.FirstOrDefaultAsync(m => m.MenuId == id);
            if (deletemenu == null) throw new KeyNotFoundException($"ไม่พบ {id}");

            _db.Menus.Remove(deletemenu);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
