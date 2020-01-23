using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BringItLibrary
{
    public class Product
    {
        // auto getter's and setter's for constantly changing values in the text file.
        public string Name { get; set; }
        public string ProductType { get; set; }
        public double Cost { get; set; }

        // A constructor so that when reading the file the data is stored correctly.
        public Product (string name, string productType, double cost)
        {
            Name = name;
            ProductType = productType;
            Cost = cost;
        }
    }
}
