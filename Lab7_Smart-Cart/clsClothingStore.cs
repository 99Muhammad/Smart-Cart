using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Lab7_Smart_Cart.clsProduct;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab7_Smart_Cart
{
    public class clsClothingStore:clsProductGenerator
    {
       
        public void GenerateProduct()
        {
            int Number = 0;
            ReadFileRowByRow("Products.txt");
           
            var FoodProducts = lsProductsInfo.Where(p => p.Category.ToString() == "Clothing");
            clsProductGenerator.generatedIDs.Clear();

            foreach (var P in FoodProducts)
            {
                
                generatedIDs.Add(P.ID);
                Console.WriteLine("\n-----------------------------------------------------------");
                Console.WriteLine($"ID ={P.ID}, ProdactName : {P.Name}, Price : {P.Price}$" +
                    $", Category : {P.Category}");
                Console.WriteLine("\n-----------------------------------------------------------");
            }

            clsShoppingCart shoppingCart = new clsShoppingCart();
           

        }

    }
}
