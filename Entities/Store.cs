
namespace CartCase.Entities
{
    public class Store : Base
    {
        public Store() 
        {
            CreatedDate = DateTime.Now;
            status = 1;
        }

        public Guid StoreId { get; set; }
        public string StoreName { get; set; } = default!;

        public int StoreType { get; set; }
    }
}
