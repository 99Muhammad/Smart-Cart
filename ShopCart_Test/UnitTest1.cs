using Lab7_Smart_Cart;

namespace ShopCart_Test
{
    public class UnitTest1
    {
        [Fact]
        public void AddItem_Test()
        {
            clsShoppingCart shoppingCart = new clsShoppingCart();

          
            int lengthBefore = shoppingCart.lsProductsChoosed.Count;

            shoppingCart.AddItem(10);
            
            
            Assert.Equal(lengthBefore+1, shoppingCart.lsProductsChoosed.Count);

        }

        [Fact]
        public void RemoveItem_Test()
        {
            clsShoppingCart shoppingCart = new clsShoppingCart();


            clsProductGenerator generator = new clsProductGenerator();
            generator.GenerateProduct();

            shoppingCart.AddItem(10);
            int lengthBefore = shoppingCart.lsProductsChoosed.Count;


            shoppingCart.DeleteItem(10);

            Assert.Equal(lengthBefore-1, shoppingCart.lsProductsChoosed.Count);

        }
    }
}