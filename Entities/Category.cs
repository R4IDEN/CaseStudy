
namespace CartCase.Entities
{
    public class Category:Base
    {
        public Category()
        {
            CreatedDate = DateTime.Now;
            status = 1;
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; } //Collection navigation property
    }
}
