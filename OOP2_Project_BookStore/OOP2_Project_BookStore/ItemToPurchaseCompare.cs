using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Project_BookStore
{
    class ItemToPurchaseCompare : IComparer<ItemToPurchase>
    {
        public int Compare(ItemToPurchase x, ItemToPurchase y)
        {
            return x.Product.getProductID().CompareTo(y.Product.getProductID());
        }
    }
}
