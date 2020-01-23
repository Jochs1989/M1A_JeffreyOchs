using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BringItLibrary
{
    public class ProductListAndValidation
    {
        // List of all products in the transaction and their data.
        public static List<Product> productsPurchased = new List<Product>();

        // Validates whether a transaction is over $10 or is a food/retail product.
        public static void PurchaseValidation()
        {
            // variables used to make sure the transaction has proper cost. Count is used incase the user has an invalid product type and will not allow the user to continue, but will still allow a reciept to be printed.
            double totalCost = 0;
            int count = 0;

            // Calcualtes total cost before taxes and charges.
            for (int i = 0; i < productsPurchased.Count; i++)
            {
                totalCost += productsPurchased[i].Cost;
            }

            Console.WriteLine("\nProducts being Purchased:");
            Console.WriteLine("---------------------------------------");
            // Validates the cost to be over $10.00
            if(totalCost >= 10)
            {
                // cycles through each product to make sure they product type is correct.
                foreach (Product products in productsPurchased)
                {
                    if (products.ProductType.ToLower() == "food" || products.ProductType.ToLower() == "retail")
                    {
                        Console.WriteLine(string.Format("{0,-15}  {1,-14}  {2,-22}", products.Name, products.ProductType, products.Cost.ToString("C2")));

                        count++;
                        // If all products are valid the transaction will then be calculated. and the user will be given a final cost. Otherwise the user will not recieve and final cost.
                        if (count == productsPurchased.Count)
                        {
                            Calculation.CostCalculation(productsPurchased);
                        }
                    }

                    // Displays the error with the transaction
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(string.Format("{0,-15}  {1,-14}  {2,-22}", products.Name, products.ProductType, products.Cost.ToString("C2")));
                        Console.WriteLine("\nOrder is invalid! There was an error in your product type!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            // Displays the error within the transaction
            else
            {
                foreach(Product products in productsPurchased)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{products.Name}, {products.ProductType}, {products.Cost.ToString("C2")}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"Total Cost = {totalCost.ToString("C2")}");
                Console.WriteLine("Order is invalid! Total cost of products is below $10.00");
            }

        }
    }
}
