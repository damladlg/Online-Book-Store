using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace OOP2_Project_BookStore
{
    class Network_
    {
        public static bool checkStatus()
        {
            bool connectionExists = false;
            try
            {
                System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
                options.DontFragment = true;
                if (!string.IsNullOrEmpty("8.8.8.8"))
                {
                    System.Net.NetworkInformation.PingReply reply = pingSender.Send("8.8.8.8");
                    connectionExists = reply.Status == System.Net.NetworkInformation.IPStatus.Success ? true : false;
                }
            }
            catch (PingException ex)
            {

            }
            return connectionExists;
        }

        public static bool MailSender(string receiver, string title, string message,string addition)
        {
            MailMessage ePosta = new MailMessage();
            try
            {
                ePosta.From = new MailAddress("oopprojemail@gmail.com");
                ePosta.To.Add(receiver);
                ePosta.Subject = title;
                ePosta.Body = message;
                ePosta.Attachments.Add(new Attachment( addition));
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("oopprojemail@gmail.com", "O159357<");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                object userState = ePosta;
                smtp.Send(ePosta);
                return true;
            }
            catch (SmtpException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "Mail Gönderme Hatası", "Dikkat", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                ((IDisposable)ePosta).Dispose();

                if (System.IO.File.Exists(@"Invoice.pdf"))
                {
                    System.IO.File.Delete(@"Invoice.pdf");
                }
            }
        }

        public static bool EmailKontrol(string inputEmail)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            try
            {
                return (new Regex(strRegex)).IsMatch(inputEmail);
            }
            catch (ArgumentException e)
            {
                return false;
            }
        }
    }
}
