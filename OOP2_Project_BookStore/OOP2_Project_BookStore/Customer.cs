using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db;
using System.Data;
namespace OOP2_Project_BookStore
{
    public class Customer
    {
        private int customer_Id;
        private string name;
        private string lastName;
        private string address;
        private string email;
        private string username;
        private string password;
        private string photo;
        private string gender;
        private string type;

        public Customer(int _customer_Id, string _name, string _lastName, string _email, string _username, string _password,string _type)
        {
            this.customer_Id = _customer_Id;
            this.name = _name;
            this.lastName = _lastName;
            this.email = _email;
            this.username = _username;
            this.password = _password;
            this.type = _type;
        }

        public Customer(int _customer_Id, string _name, string _lastName, string _email, string _username, string _password, string _type, string _gender,string _address,string _photo)
        {
            this.customer_Id = _customer_Id;
            this.name = _name;
            this.lastName = _lastName;
            this.email = _email;
            this.username = _username;
            this.password = _password;
            this.type = _type;
            this.gender = _gender;
            this.photo = _photo;
            this.address = _address;
        }

        public Customer(Customer user)
        {
            this.customer_Id = user.Customer_Id;
            this.name = user.Name;
            this.lastName = user.LastName;
            this.email = user.Email;
            this.username = user.Username;
            this.password = user.Password;
            this.address = user.Address;
            this.photo = user.Photo;
            this.gender = user.Gender;
            this.type = user.Type;
        }
        
        public string printCustomerDetails()
        {
            string message= "Adı: " + this.name + "" + this.lastName + "\nEmail: " + this.email ;
            if (!address.Equals(""))
                message += "\nAdres: " + this.address;

            return message+ "\nKullanıcı adı:" + this.username;
        }

        public bool SaveCustomer(string databaseName)
        {
            try
            {
                DatabaseOperations db = new DatabaseOperations(databaseName);
                DataTable dt;

                dt = db.Select("select id from tbl_gender where Type_Name='"+this.gender+"'");
                int genderId = int.Parse(dt.Rows[0][0].ToString());

                dt = db.Select("select id from tbl_userType where Type_Name='"+type+"'");
                int typeID = int.Parse(dt.Rows[0][0].ToString());

                int result = db.UD("@update tbl_user set Name='" + this.name + "',LastName='" + this.lastName + "',Address='" +
                                    this.address + "',Email='" +this.email + "',Username='" + this.username + "',Password='" + 
                                    this.password + "',Gender_ID=" + genderId + ",Type_ID=" + typeID + ",Photo='" + this.Photo +
                                    "' where id=" + customer_Id + "");
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public List<string> printCustomerPurchases(string databaseName)
        {
            List<string> list = new List<string>();
            try
            {
                DatabaseOperations db = new DatabaseOperations(databaseName);
                DataTable dtSelling = db.Select(@"select s.Amount,pt.Type_Name from tbl_selling  s
                                                    join tbl_paymentType pt on s.Payment_Type_ID = pt.id
                                                    where s.User_ID = " + customer_Id);
                DataTable dtProducForSelling;
                for (int i = 0; i < dtSelling.Rows.Count; i++)
                {
                    dtProducForSelling = db.Select(@"select p.Price,pt.Type_Name from  tbl_productSelling ps
                                                        join tbl_products p on ps.Product_ID = p.id
                                                        join tbl_productType pt on pt.id = p.Product_Type_ID
                                                        where ps.Selling_ID =" + dtSelling.Rows[i][0]);
                    int bookcount = 0;
                    int magazinecount = 0;
                    int MusicCDcount = 0;
                    for (int j = 0; j < dtProducForSelling.Rows.Count; j++)
                    {
                        if (dtProducForSelling.Rows[j][1].ToString().Equals("Book"))
                        {
                            bookcount++;
                        }
                        else if (dtProducForSelling.Rows[j][1].ToString().Equals("Magazine"))
                        {
                            magazinecount++;
                        }
                        else if (dtProducForSelling.Rows[j][1].ToString().Equals("MusicCD"))
                        {
                            MusicCDcount++;
                        }
                    }
                    string temp = "Toplamda " + dtSelling.Rows[i][0] + " olmak üzere: " + bookcount + " kitap, " + magazinecount + " magazin, " + MusicCDcount + " müzikCD alınmış.";
                    list.Add(temp);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return list;
            }
        }

        public int Customer_Id
        {
            get { return this.customer_Id; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string Photo
        {
            get { return this.photo; }
            set { this.photo = value; }
        }

        public string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }
}
