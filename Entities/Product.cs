
namespace CartCase.Entities
{
    public class Product :Base
    {
        public Product() 
        {
            CreatedDate = DateTime.Now;
            status = 1;
        }

        public int ProductId { get; init; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public string? Summary { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; } //Foreign Key

        public Store Store { get; set; } = default!;
        public Category? Category { get; set; } //Navigation Property
    }
}
