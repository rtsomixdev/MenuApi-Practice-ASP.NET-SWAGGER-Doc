using MENUAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MENUAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MenuMaterial> MenuMaterials { get; set; }
    }
}
