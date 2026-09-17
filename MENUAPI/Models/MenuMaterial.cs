namespace MENUAPI.Models
{
    public class MenuMaterial
    {
        public int MenuMaterialId { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
