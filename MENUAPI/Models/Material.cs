namespace MENUAPI.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<MenuMaterial> MenuMaterials { get; set; } = new List<MenuMaterial>();
    }
}
