namespace MENUAPI.DTOs
{
    public class RequestMaterialDTO
    {
        public string MaterialName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
    }
}
