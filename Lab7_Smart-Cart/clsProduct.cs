using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Smart_Cart

{

    public class clsProduct
    {


      
        public enum enProductCategory
        {
            Food, Clothing, Electronics
        }

        public struct stProductsInfo
        {
          public int ID;
          public string Name;
          public double Price;
          public double TotalCost;
          public enProductCategory Category;
        }

        public stProductsInfo stProducts; 
        public static List<stProductsInfo> lsProductsInfo = new List<stProductsInfo>();
        public static HashSet<int> generatedIDs = new HashSet<int>();

        
    }
}


