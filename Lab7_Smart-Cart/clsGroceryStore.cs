using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Smart_Cart
{
    public class clsGroceryStore:clsProductGenerator
    {
        
        int Number = 0;
        public void GenerateProduct()
        {
            ReadFileRowByRow("Products.txt");
            clsProductGenerator.generatedIDs.Clear();
            var GrocaryProducts = lsProductsInfo.Where(p => p.Category.ToString() == "Food");

            foreach (var P in GrocaryProducts)
            {
                generatedIDs.Add(P.ID);
                Console.WriteLine("\n-----------------------------------------------------------");
                Console.WriteLine($"ID ={P.ID}, ProdactName : {P.Name}, Price : {P.Price}$" +
                    $", Category : {P.Category}");
                Console.WriteLine("\n-----------------------------------------------------------");
            }

        }

        }
}
