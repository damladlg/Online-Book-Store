using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Project_BookStore
{
    public class LoginedCustomer
    {
        private Customer user;
        private static bool loggedOut=true;
        private static LoginedCustomer _user;
        private ShoppingCart shopCard;

        private LoginedCustomer(Customer _u)
        {
            this.user = new Customer(_u);
            loggedOut = false;
            shopCard = new ShoppingCart(_u.Customer_Id);
        }

        private LoginedCustomer() { }

        public static LoginedCustomer Singleton(Customer _u)
        {
            if (_user == null||loggedOut)
                _user = new LoginedCustomer(_u);
            return _user;
        }

        public static LoginedCustomer Singleton()
        {
            if (_user == null)
                _user = new LoginedCustomer();
            return _user;
        }

        public Customer User
        {
            get { return this.user; }
            set { this.user = value; }
        }

        public static bool LoggedOut
        {
            get { return loggedOut; }
            set { loggedOut = value; }
        }

        public ShoppingCart ShopCard
        {
            get { return shopCard; }
            set { shopCard = value; }
        }
        
        public void RefreshCard()
        {
            MainForm.lblproduct.Text = ShopCard.PrintProducts();
        }
    }
}