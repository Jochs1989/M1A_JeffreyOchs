using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BringItLibrary
{
    public class Calculation
    {
        // Method used to gather all charges and product costs based on product type.
        public static void CostCalculation(List<Product> products)
        {
            // Created a list inside a list to allow the return of multiple from other methods.
            List<List<double>> collectionOfCosts = new List<List<double>>();
            // Goes through each product and sorts the cost and charges based on type using a switch.
            for (int i = 0; i < products.Count; i++)
            {
                switch (products[i].ProductType.ToLower().Trim())
                {
                    case "food":
                        collectionOfCosts.Add(FoodTax(products[i]));
                        break;

                    case "retail":
                        collectionOfCosts.Add(RetailTax(products[i]));
                        break;
                    default:
                        break;
                }
            }
            // Used to calculated the final cost after all charges and costs.
            TotalSales(collectionOfCosts, products);
        }

        // Stores the cost and charges of a single food product.
        public static List<double> FoodTax(Product product)
        {
            // Holds the product's charges and costs.
            List<double> foodTaxes = new List<double>();

            // Variables for the tax amount's I found for cumberland county.
            double stateTax = 0.0475;
            double countyTax = .0325;
            double serviceChargeStore = .1;
            double serviceChargeBringIt = .1;

            // Adds all charges and costs to the list.
            foodTaxes.Add(serviceChargeBringIt *= product.Cost);
            foodTaxes.Add(serviceChargeStore *= product.Cost);
            foodTaxes.Add(stateTax *= (serviceChargeBringIt + product.Cost + serviceChargeStore));
            foodTaxes.Add(countyTax *= (serviceChargeBringIt + product.Cost + serviceChargeStore));
            foodTaxes.Add(product.Cost);

            // Prints a reciept of the product.
            StandardMessages.ProductReciept(product, serviceChargeBringIt + serviceChargeStore, stateTax, countyTax);

            return foodTaxes;
        }

        // Stores the cost and charges of a single retail product.
        public static List<double> RetailTax(Product product)
        {
            // Holds the product's charges and costs.
            List<double> retailTaxes = new List<double>();

            // Variables for the tax amount's I found for cumberland county.
            double stateTax = 0.0475;
            double countyTax = .0225;
            double bringItCharge = .05;

            // Adds all charges and costs to the list.
            retailTaxes.Add(bringItCharge *= product.Cost);
            retailTaxes.Add(stateTax *= product.Cost);
            retailTaxes.Add(countyTax *= product.Cost);
            retailTaxes.Add(product.Cost);

            // Prints a reciept of the product.
            StandardMessages.ProductReciept(product, bringItCharge, stateTax, countyTax);

            return retailTaxes;
        }

        // Creates a reciept based on all products cost and charges added together.
        public static void TotalSales(List<List<double>> collectionOfCosts, List<Product> product)
        {
            double totalCost = 0;

            // Used just incase something went horribly wrong and a product got through that had no information. Should never happen.
            if (product is null)
            {
                Console.WriteLine("There was no products listed");
            }
            else
            {
                // Used 2 loops because of the List being nested in one another. Takes each individual cost and adds them together to produce a total sales cost for the user.
                foreach (List<double> productCost in collectionOfCosts)
                {
                    foreach (double salesCost in productCost)
                    {
                        totalCost += salesCost;
                    }
                }
                // Displays the Final Cost receipt.
                StandardMessages.TotalCostReceipt(totalCost);
            }

        }
    }
}
