using CartCase.Entities;

namespace CartCase.Models
{
    public class SessionCart : Cart
    {
        //check cart from session can be add here.
        
        public override int AddItem(Product product, int quantity)
        {
            return base.AddItem(product, quantity);
        }
        public override void ClearCart()
        {
            base.ClearCart();
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
        }

    }
}
