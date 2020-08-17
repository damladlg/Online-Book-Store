using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Project_BookStore
{
    public class ItemToPurchase
    {
        private Product product;
        private int quantity;

        public ItemToPurchase(Product _p, int _q)
        {
            product = _p;
            quantity = _q;
        }

        public Product Product { get => product; set => product = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public static bool operator ==(ItemToPurchase I, ItemToPurchase _I)
        {
            return I.Product.getProductID() == _I.Product.getProductID();
        }

        public static bool operator !=(ItemToPurchase I, ItemToPurchase _I=null)
        {
            int Itmp =I.Product.getProductID();
            int _Itmp = _I.Product.getProductID();
           
            return Itmp != _Itmp;
        }
        

        public static bool operator <(ItemToPurchase I, ItemToPurchase _I)
        {
            return I.Product.getProductID() < _I.Product.getProductID();
        }

        public static bool operator >(ItemToPurchase I, ItemToPurchase _I)
        {
            return I.Product.getProductID() > _I.Product.getProductID();
        }

        public static bool operator <=(ItemToPurchase I, ItemToPurchase _I)
        {
            return I.Product.getProductID() <= _I.Product.getProductID();
        }

        public static bool operator >=(ItemToPurchase I, ItemToPurchase _I)
        {
            return I.Product.getProductID() >= _I.Product.getProductID();
        }

        public bool Equals( ItemToPurchase _I)
        {
            return  this.product.getProductID() == _I.Product.getProductID();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ItemToPurchase);
        }

        public override int GetHashCode()
        {
            var hashCode = 352033288;
            hashCode = hashCode * ((-1521134295) + this.product.getProductID().GetHashCode());
            return hashCode;
        }
        
    }
}