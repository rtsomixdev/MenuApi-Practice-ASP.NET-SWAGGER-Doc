namespace MENUAPI.DTOs
{
    public class ResponseMenuMaterialDTO
    {
        public int MenuId { get; set; }
        public int MaterialId { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public string MaterialName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
