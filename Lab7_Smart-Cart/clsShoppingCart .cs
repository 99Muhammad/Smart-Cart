using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab7_Smart_Cart
{
    
    public class clsShoppingCart:clsProduct
    {
      
     public  List<stProductsInfo> lsProductsChoosed = new List<stProductsInfo>();
        enum enUserChoise
        {
            View=1,
            Delete=2,
            ViewUserCart=3,
            ViewClothingStore=4,
            ViewGroceryStrore=5
          
        }


        public void MainMenueScreen()
        {

            Console.WriteLine("\t\t-----------------------------------------------\n");
            Console.WriteLine("\t\t\tMain Menue Screen\n");
            Console.WriteLine("\t\t-----------------------------------------------\n");
            ImplementUserChoise();

        }
        public bool CheckUserInput( ref int UserChoise)
        {
            while (true)
            {
                if(int.TryParse(Console.ReadLine(), out int userChoise))
                {
                    if(userChoise>=1&&userChoise<=5)
                    {
                        UserChoise = userChoise;
                        break;
                    }
                    else
                    {
                        Console.Write($"\t\t\tThe value that you entered is {userChoise} , Note should " +
                            $"be between 1 and 3 ,try again!");
                    }
                }
                else
                {
                    Console.Write("\t\t\tInvalid Input ,try again !");
                }
            }
            return true;
        }
        public int WhatUserWantDo()
        {
            Console.WriteLine("\t\t\tWhat do you want to do ?");
            Console.WriteLine("\t\t\tTo view all items --> Press 1");
            Console.WriteLine("\t\t\tTo remove item from your cart --> Press 2");
            Console.WriteLine("\t\t\tTo view item from your cart --> Press 3");
            Console.WriteLine("\t\t\tTo view all clothing item --> Press 4");
            Console.WriteLine("\t\t\tTo view all grocery item  --> Press 5");
         

            Console.Write("\t\t\t");
            int UserChoise = 0;
            CheckUserInput(ref UserChoise);
            return UserChoise;

        }

        public bool isValidNumber(ref int Number)
        {
            int number;
            while (!int.TryParse(Console.ReadLine(),out number))
            {
                Console.Write("\t\t\tYou intered invalid number,try again!");

            }
            Number = number;
            return true;
        }
        public string YesOrNoAnswer(string Message)
        {
            string Answer = "";
            while (true)
            {
                Console.Write($"\t\t\t{Message}");
                 Answer = Console.ReadLine().ToLower();
                if (Answer == "yes" || Answer == "no")
                    return Answer;
                
            }
            return Answer;
        }

       public void GetID_FromUser(ref int Number)
        {
          
            string Answer = "";
            Console.Write("\t\t\tEnter the ID of the item ? ");
            isValidNumber(ref Number);
            while (!clsProductGenerator.generatedIDs.Contains(Number))
            {
                Console.WriteLine("\t\t\tInvalid ID ,try again :-(");
                Answer = YesOrNoAnswer("Do you to enter another one ?");
                
                if (Answer == "yes")
                {
                    isValidNumber(ref Number);
                   
                }
                else if (Answer == "no")
                {
                    return;
                }
            }
        }

        public void PrintItemInfo(stProductsInfo item)
        {
            Console.WriteLine("\n\t\t\tThis item you want to delete it :\n");
            Console.WriteLine("\n\t\t----------------------------------------------------------");
            Console.WriteLine($"\t\tID ={item.ID}, ProdactName : {item.Name}, Price : {item.Price}$" +
                $", Category : {item.Category}");
            Console.WriteLine("\n\t\t----------------------------------------------------------");
        }
        public void ImplementUserChoise()
        {
            int Number=0;

            enUserChoise userChoise = (enUserChoise)WhatUserWantDo();
            switch (userChoise)
            {
                case enUserChoise.View:
                    {
                       
                        ViewAllItems();
                        while(YesOrNoAnswer("Do you want to add items?") == "yes")
                       
                            GetID_FromUser(ref Number);
                            AddItem(Number);

                        break;
                    }

              
                case enUserChoise.Delete:

                    {
                        ViewUserCart();
                        while(YesOrNoAnswer("Do you to delete item?") == "yes")
                      
                        {
                            Console.Write("\t\tEnter the item ID's you wnat to delete it");
                            isValidNumber(ref Number);
                            stProductsInfo item = Find(Number, stProducts);
                            if (item.ID==default)
                            {
                                Console.WriteLine($"\t\t\tThe ID you enterd is NOT exist :-(");
                                Console.WriteLine("\t\t\tTry again!");
                                continue;
                                //return;
                            }
                            else
                            {
                                PrintItemInfo(item);
                                if (YesOrNoAnswer("Are you sure you want to delete it ?") == "yes")
                                {
                                    DeleteItem(Number);
                                    
                                        Console.WriteLine("\n\t\tDelted done successfully :-)");
                                        Console.WriteLine("\n\t\tYour Item(s) is/are :");
                                        ViewUserCart();
                                }
                            }

                        }
                       
                        break;
                    }
                case enUserChoise.ViewUserCart:

                    {
                        ViewUserCart();
                        if(lsProductsChoosed.Count>0)
                        {
                            while(YesOrNoAnswer("Do you to delete item?") == "yes")
                           
                            {
                                Console.Write("\t\tEnter the item ID's you wnat to delete it");
                                isValidNumber(ref Number);
                                stProductsInfo item = Find(Number, stProducts);
                                if (item.ID == default)
                                {
                                    Console.WriteLine($"\t\t\tThe ID you enterd is NOT exist :-(");
                                    Console.WriteLine("\t\t\tTry again!");
                                    continue;
                                   
                                }
                                PrintItemInfo(item);
                                if (YesOrNoAnswer("Are you sure you want to delete it ?") == "yes")
                                {
                                    DeleteItem(Number);
                                    Console.WriteLine("\n\t\tDelted done successfully :-)");
                                    Console.WriteLine("\n\t\tYour Item(s) are :");
                                    ViewUserCart();
                                }
                            }
                        }
                       
                      
                        break;
                    }
                case enUserChoise.ViewClothingStore:

                    {
                        clsClothingStore clothingStore = new clsClothingStore();
                        clothingStore.GenerateProduct();
                        while(YesOrNoAnswer("Do you want to add items?") == "yes")
                     
                        {
                            GetID_FromUser(ref Number);
                            AddItem(Number);
                            Console.WriteLine("\n\t\tProduct added succesfully :-)");
                            Console.WriteLine("\n\t\tYour Item(s) : ");
                            ViewUserCart();
                        }
                      
                        break;
                    }

                case enUserChoise.ViewGroceryStrore:

                    {
                        clsGroceryStore groceryStore = new clsGroceryStore();
                        groceryStore.GenerateProduct();
                        while(YesOrNoAnswer("Do you want to add items?") == "yes")
                       
                        {
                            GetID_FromUser(ref Number);
                            AddItem(Number);
                            Console.WriteLine("\n\t\tProduct added succesfully :-)");
                            Console.WriteLine("\n\t\tYour Item(s) : ");
                            ViewUserCart();
                        }
                       
                        break;
                    }
               
            }
        }

        public void ViewAllItems()
        {
            Console.Clear();
            Console.WriteLine("\t\t-----------------------------------------------\n");
            Console.WriteLine("\t\t\t\tItems Screen\n");
            Console.WriteLine("\t\t-----------------------------------------------\n");
          
            clsProductGenerator generator = new clsProductGenerator();
            generator.GenerateProduct();
        }

       
        public void AddItem(int Number)
        {
            
                stProductsInfo matchingProduct = clsProduct.lsProductsInfo.Find(p => p.ID == Number);
                stProducts.TotalCost += matchingProduct.Price;
                lsProductsChoosed.Add(matchingProduct);

        }

        public stProductsInfo Find(int ID, stProductsInfo item)
        {
           
            foreach (var product in lsProductsChoosed)
            {
                if(product.ID==ID)
                {
                    item = product;
                    break;
                }
            }
            return item;
        }
        public void DeleteItem(int ID)
        {
           
         foreach (var product in lsProductsChoosed)
                {
                    if (product.ID == ID)
                    {
                        stProducts.TotalCost -= product.Price;
                        lsProductsChoosed.Remove(product);
                        return ;
                    }
                }
 
        
        }

        public void ViewUserCart()
        {
           
            if(lsProductsChoosed.Count==0)
            {
                Console.WriteLine("\n\t\t\tYour cart is empty :-(");
                return;
            }

            foreach(var item in lsProductsChoosed)
            {
                Console.WriteLine("\n\t\t----------------------------------------------------------");
                Console.WriteLine($"\t\tID ={item.ID}, ProdactName : {item.Name}, Price : {item.Price}$" +
                    $", Category : {item.Category}");
                Console.WriteLine("\n\t\t----------------------------------------------------------");
            }
            Console.WriteLine($"\n\t\tTotal Cost : {stProducts.TotalCost}$\n");

        }

    }
}
