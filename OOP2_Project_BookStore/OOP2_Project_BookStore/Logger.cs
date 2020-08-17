using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Db;
namespace OOP2_Project_BookStore
{
    public class Logger
    {
        public static void logger(string button, EventLogEntryType type)
        {
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            DatabaseOperations db = new DatabaseOperations("db_BookStore");
            LoginedCustomer lu = LoginedCustomer.Singleton();
            object a=db.I(@"insert into tbl_log (User_Name,Button,Time,Entry_Type) values('" + lu.User.Username + "','" + button + "','" + time.ToString(format) + "','" + type + "')");
        }
    }

}
