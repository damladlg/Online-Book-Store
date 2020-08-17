using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP2_Project_BookStore
{
    class Book : Product
    {
        private string ISBNnumber;
        private string author;
        private string publisher;
        private string page;

        public Book() { }

        public Book(string _ISBNnumber, string _author, string _publisher, string _page, string _name, decimal _price, Image _photo, int _stock, int _soldCount,int _id)
        {
            ISBNnumber = _ISBNnumber;
            author = _author;
            publisher = _publisher;
            page = _page;
            Name = _name;
            ID = _id;
            Price = _price;
            Photo = _photo;
            Stock = _stock;
            SoldCount = _soldCount;
        }

        public string ISBNNumber { get => ISBNnumber; set => ISBNnumber = value; }
        public string Author { get => author; set => author = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string Page { get => page; set => page = value; }

        public override string getProductName()
        {
            return this.Name;
        }

        public override int getProductID()
        {
            return this.ID;
        }

        public override decimal getProductPrice()
        {
            return this.Price;
        }

        public override string printProperties()
        {
            return "ISBN: " + this.ISBNnumber + "\nYazar: " + this.Author + "\nYayıncı: " + this.Publisher + "\nSayfası: " + this.Page;
        }
    }
}