using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindApp.ProductServiceRef;
using System.ServiceModel; 

namespace NorthwindApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowOperations();
        }

        private static  void ShowOperations()
        {
            ConsoleKeyInfo cki;

            do
            {
                Console.WriteLine(); 
                Console.WriteLine("Enter Product ID or press Esc to quit : ");
                cki = Console.ReadKey();
                if (!char.IsNumber(cki.KeyChar))
                {
                    Console.WriteLine("  Invalid number");
                }
                else
                {
                    Int32 number;
                    if (Int32.TryParse(cki.KeyChar.ToString(), out number))
                    {
                        Console.WriteLine(); 
                        GetProductName(number);
                        GetProductQty(number);
                        GetCategoryName(number);  
                    }
                    else
                    {
                        Console.WriteLine("Unable to parse input");
                    }
                }
            } while (cki.Key != ConsoleKey.Escape);

            Console.Read(); 
        }

        private static void GetProductName(int ProductID)
        {   
            try
            {
                ProductsClient client = new ProductsClient();
                string ProductName = client.GetProductName(ProductID);
                Console.WriteLine(string.Format("Product name {0} for Product ID {1}", ProductName, ProductID));
            }
            catch (FaultException<ServiceException> ex)
            {
                Console.WriteLine(string.Format("Errors occured in service : {0} ", ex.Detail.Message));
            }
        }

        private static void GetProductQty(int ProductID)
        {   
            try
            {
                ProductsClient client = new ProductsClient();
                int ProductQty = client.GetProductQty(ProductID);
                Console.WriteLine(string.Format("Product qty {0} for Product ID {1}", ProductQty, ProductID));
            }
            catch (FaultException<ServiceException> ex)
            {
                Console.WriteLine(string.Format("Errors occured in service : {0} ", ex.Detail.Message));
            }
        }

        private static void GetCategoryName(int ProductID)
        {
            try
            {
                ProductsClient client = new ProductsClient();
                string CategoryName = client.GetCategoryName(ProductID);
                Console.WriteLine(string.Format("Category name {0} for Product ID {1}", CategoryName, ProductID));
            }
            catch (FaultException<ServiceException> ex)
            {
                Console.WriteLine(string.Format("Errors occured in service : {0} ", ex.Detail.Message));
            }
        }
    }
}
