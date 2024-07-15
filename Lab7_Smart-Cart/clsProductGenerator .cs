using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Lab7_Smart_Cart.clsProduct;

namespace Lab7_Smart_Cart
{
    public class clsProductGenerator:clsProduct
    {

   
        private void CheckCategory(string CategoryName)
        {
            switch (CategoryName)
            {
                case "Food":
                    stProducts.Category = enProductCategory.Food;
                    break;

                case "Electronics":
                    stProducts.Category = enProductCategory.Electronics;
                    break;

                case "Clothing":
                    stProducts.Category = enProductCategory.Clothing;
                    break;
            }
        }


        public List<string> ConvertLineToList(string text)
        {

            List<string> lsText = text.Split(',').ToList();

           stProducts.ID = Convert.ToInt32(lsText[0]);
           stProducts.Name = lsText[1];
           stProducts.Price = Convert.ToDouble(lsText[2]);
            CheckCategory(lsText[3].Trim());

            lsProductsInfo.Add(stProducts);
            return lsText;

        }
        public void PrintProductInfo(int id)
        {

            var product = lsProductsInfo.FirstOrDefault(p => p.ID == id);
          
                Console.WriteLine("\n\t\t----------------------------------------------------------");
                Console.WriteLine($"\t\tID ={product.ID}, ProdactName : {product.Name}, Price : {product.Price}$" +
                    $", Category : {product.Category}");
                Console.WriteLine("\n\t\t----------------------------------------------------------");
          
        }
        public void ReadFileRowByRow(string filepathParam)
        {
            List<string> lsText2 = new List<string>();
            if (File.Exists(filepathParam))
            {
                Console.WriteLine("File content:");
                foreach (string line in File.ReadLines(filepathParam))
                {
                    lsText2 = ConvertLineToList(line);
                }
            }
            else
            {
                Console.WriteLine("File not exist: " + filepathParam);
            }

        }
       

        public void GenerateProduct()
        {
            ReadFileRowByRow("Products.txt");

            Random random = new Random();
            int Count = 0;

            clsProductGenerator.generatedIDs.Clear();
            while (Count++ < 10)
            {
                int currentRandomNum = random.Next(1, 39);

                if (!generatedIDs.Contains(currentRandomNum))
                {
                    generatedIDs.Add(currentRandomNum);
                   
                    PrintProductInfo(currentRandomNum);
                }
                else
                {
                    Count--;
                }
            }

            }

        }
    
} 
