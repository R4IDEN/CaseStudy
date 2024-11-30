
namespace CartCase.Entities
{
    public class CartLine
    {
        public Guid CartLineId { get; set; }
        public int Quantity { get; set; }

        public Guid customerId { get; set; } = default!;
        public Product product { get; set; } = default!;
        public Store store { get; set; } = default!;
    }
}
