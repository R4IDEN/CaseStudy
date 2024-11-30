using static System.Formats.Asn1.AsnWriter;

namespace CartCase.Entities
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }

        public Cart() 
        {
            Lines = new List<CartLine>();
        }

        //Add a line for CartLine
        //return type should be with _returnCode (1:success, 2:noStock, 3:error, etc.)
        public virtual int AddItem(Product _product, int _quantity)
        {
            CartLine? line = Lines.Where
                (l => l.product.ProductId == _product.ProductId && l.product.Store.StoreId == _product.Store.StoreId).FirstOrDefault();

            if(_product.Stock <= 0) 
                return 2;

            if (line is null )
            {
                Lines.Add(new CartLine()
                {
                    product = _product,
                    Quantity = _quantity,
                    store = _product.Store
                });
            }
            else
                line.Quantity += _quantity;

            _product.Stock--;
            return 1;
        }

        //Remove line for CartLine
        public virtual void RemoveLine(Product _product) => Lines.RemoveAll(l => l.product.ProductId == _product.ProductId && l.product.Store.StoreId == _product.Store.StoreId);

        //Apply Discount
        // Coupon check -> coupon apply -> Cart total update

        //Clear Cart
        public virtual void ClearCart() => Lines.Clear();

        //Calculate Total Value
        public decimal ComputeTotalValue() => Lines.Sum(e => e.product.Price * e.Quantity);

        //To view all cart product
        public IEnumerable<CartLine> getCartItems() => Lines;
    }
}
