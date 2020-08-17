using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Project_BookStore
{
    public abstract class Product
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public decimal Price { get; set; }
        public Image Photo { get; set; }
        public int Stock { get; set; }
        public int SoldCount { get; set; }

        public abstract string getProductName();
        public abstract int getProductID();
        public abstract decimal getProductPrice();
        public abstract string printProperties();
    }
}
