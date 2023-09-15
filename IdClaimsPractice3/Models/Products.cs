namespace IdClaimsPractice3.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
    }
}
