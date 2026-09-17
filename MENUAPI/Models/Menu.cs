namespace MENUAPI.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<MenuMaterial> MenuMaterials { get; set; } = new List<MenuMaterial>();
    }
}
