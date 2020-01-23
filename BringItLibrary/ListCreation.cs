using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BringItLibrary
{
    public class ListCreation
    {
        public static void ReadOrder()
        {
            // Used a Directory which will allow the user to enter multiple text files TODO: Figure out how to seperate each text file into it's own transation.
            string[] filePaths = Directory.GetFiles(@"../../../ProductPurchase", "*.txt");

            // reads each file and puts them together as a single transation in case of multiple entries.
            foreach (string file in filePaths)
            {
                // Used to read the file
                using (StreamReader fileReader = new StreamReader(file))
                {
                    // Reads the file till there is no more data.
                    while (!fileReader.EndOfStream)
                    {
                        // Assigns line a value.
                        string name = fileReader.ReadLine();
                        string productType = fileReader.ReadLine();
                        string price = fileReader.ReadLine();
                        string blankspace = fileReader.ReadLine();

                        // Used incase the transation has an invalid price.
                        if(double.TryParse(price.Replace("$", "").Replace(",", ""), out double newPrice))
                        {
                            // Adds the product to a list with all its attributes.
                            ProductListAndValidation.productsPurchased.Add(new Product(name, productType, newPrice));
                        }
                        else
                        {
                            // Displays an Error in case the transaction data is invalid, but still creates a reciept for the user. So the program doesn't crash.
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n{name} has an invalid Price: {price}");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Product type changed to invalid! Transaction will be canceled and a reciept will be created!");
                            Console.ForegroundColor = ConsoleColor.White;
                            ProductListAndValidation.productsPurchased.Add(new Product(name, "invalid", 0));

                        }

                    }
                }
            }
        }
    }
}
