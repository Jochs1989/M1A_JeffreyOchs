using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BringItLibrary
{
    public class StandardMessages
    {
        // Displays a menu for the user to run their transaction.
        public static string Menu()
        {

            Console.WriteLine("\nWelcome to BringIt.me");
            Console.Write("Would you like to run your transation? > ");


            return Console.ReadLine();
        }

        // Provides a reciept based on whether the product type is food or retail.
        public static void ProductReciept(Product product, double charges, double stateTax, double countyTax)
        {
            if (product.ProductType.ToLower() == "retail")
            {
                // Used a string format so that everything looks neat and displays correctly
                Console.WriteLine("\nProduct\t\t Cost\t\t Service Charge (5%)\t State Tax (4.75%)\t County Tax (2.25%)");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine(string.Format("{0,-15}  {1,-14}  {2,-22}  {3,-22}  {4,-22}", product.Name, product.Cost.ToString("C2"), charges.ToString("C2"), stateTax.ToString("C2"), countyTax.ToString("C2")));
            }
            else
            {
                // Used a string format so that everything looks neat and displays correctly
                Console.WriteLine("\nProduct\t\t Cost\t\t Service Charge (20%)\t State Tax (4.75%)\t County Tax (3.25%)");
                Console.WriteLine("------------------------------------------------------------------------------------------");
                Console.WriteLine(string.Format("{0,-15}  {1,-14}  {2,-22}  {3,-22}  {4,-22}", product.Name, product.Cost.ToString("C2"), charges.ToString("C2"), stateTax.ToString("C2"), countyTax.ToString("C2")));
            }
        }
        // Displays a recipt for the total amount of all charges and costs.
        internal static void TotalCostReceipt(double totalCost)
        {
            Console.WriteLine($"\nThe Total Cost of the transation is: {totalCost.ToString("C2")}");
        }
    }
}
