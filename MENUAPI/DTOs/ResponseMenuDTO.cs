namespace MENUAPI.DTOs
{
    public class ResponseMenuDTO
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
