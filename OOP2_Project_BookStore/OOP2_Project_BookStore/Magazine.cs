using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace OOP2_Project_BookStore
{
    public enum MagazineType { Actual, News, Sport, Computer, Technology }
    class Magazine:Product
    {
        private string issue;
        private MagazineType type;
        
        public Magazine() { }

        public Magazine(string _issue, MagazineType _type, string _name, decimal _price, Image _photo, int _stock, int _soldCount,int _id)
        {
            issue = _issue;
            type = _type;
            Name = _name;
            ID = _id;
            Price = _price;
            Photo = _photo;
            Stock = _stock;
            SoldCount = _soldCount;
        }

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
            return "Başlık: " + this.issue + "\nTürü: " + this.type;
        }
    }
}
