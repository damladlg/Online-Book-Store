using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Project_BookStore
{
    public class Factory
    {
        static public Product PoductFactory(string type, int _id, string _name, decimal _price, Image _photo, int _stock, int _soldCount, string properties)
        {
            string[] temp = properties.Split('-');
            if (type == "Book")
            {
                return new Book(temp[0], temp[1], temp[2], temp[3], _name, _price, _photo, _stock, _soldCount, _id);
            }
            else if (type == "Magazine")
            {
                if (temp[1] == "Actual")
                    return new Magazine(temp[0], MagazineType.Actual, _name, _price, _photo, _stock, _soldCount, _id);
                else if (temp[1] == "Computer")
                    return new Magazine(temp[0], MagazineType.Computer, _name, _price, _photo, _stock, _soldCount, _id);
                else if (temp[1] == "News")
                    return new Magazine(temp[0],MagazineType.News, _name, _price, _photo, _stock, _soldCount, _id);
                else if (temp[1] == "Sport")
                    return new Magazine(temp[0], MagazineType.Sport, _name, _price, _photo, _stock, _soldCount, _id);
                else
                    return new Magazine(temp[0], MagazineType.Technology, _name, _price, _photo, _stock, _soldCount, _id);
            }
            else
            {
                if (temp[1] == "Romance")
                    return new MusicCD(temp[0], Type.Romance, _name, _price, _photo, _stock, _soldCount, _id);
                else if (temp[1] == "HardRock")
                    return new MusicCD(temp[0], Type.HardRock, _name, _price, _photo, _stock, _soldCount, _id);
                else if (temp[1] == "Country")
                    return new MusicCD(temp[0], Type.Country, _name, _price, _photo, _stock, _soldCount, _id);
                else
                    return new MusicCD(temp[0], Type.Pop, _name, _price, _photo, _stock, _soldCount, _id);
            }
        }
    }
}
