namespace Lab7_Smart_Cart
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            clsShoppingCart shoppingCart = new clsShoppingCart();
            do
            {
                 Console.Clear();
                shoppingCart.MainMenueScreen();
                Console.WriteLine();
               
            } while (shoppingCart.YesOrNoAnswer("Do you want to complete your shopping?") == "yes");
           
            Console.WriteLine("\n\t\t-----------------------------------");
            Console.WriteLine("\n\t\t     Your shopping is ended :-) ");
            Console.WriteLine("\n\t\t-----------------------------------\n");

        }
    }
}
