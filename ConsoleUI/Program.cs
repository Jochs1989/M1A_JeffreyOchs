using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BringItLibrary;

/*
 * Jeffrey Ochs
 * M1A
 * 01/22/2020
 * Capstone Assesment 
 */

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            // Variable for true false used incase user wants to continue the program.
            bool exit = false;

            // Reads the order at the start of the program. Will notify user immediately if there is an error in their pricing.
            ListCreation.ReadOrder();

            do
            {
                // Switch that uses goes to menu options and uses the user's choice.
                switch(StandardMessages.Menu())

                {
                    case "yes":
                        {
                            // "" is for cleaning up apperance and then the program records the user's text file into a list for use in calculation.
                            Console.WriteLine("");
                            // Validates whether the user entered the products correctly or with a proper amount.
                            ProductListAndValidation.PurchaseValidation();
                            break;
                        }
                    case "no":
                        {
                            // Exit's the program if the user says no.
                            exit = true;
                            break;
                        }
                }
            } while (exit == false);

        }
    }
}
