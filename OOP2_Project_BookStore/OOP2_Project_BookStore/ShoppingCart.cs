using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Windows.Forms;

namespace OOP2_Project_BookStore
{
    public class ShoppingCart
    {
        private int sellingId;
        public int SellingId
        {
            get { return sellingId; }
            set { sellingId = value; }
        }
        private int customerId;
        private DatabaseOperations Db;
        public int CustomerId { get => CustomerId; set => CustomerId = value; }

        private decimal paymentAmount;
        public decimal GetPaymentAmount() { return paymentAmount; }

        private int paymentType;
        public int PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        public ArrayList Products = new ArrayList();
        
        public ShoppingCart(int _customerId, int _paymentType=1)
        {
            paymentAmount = 0;
            Db = new DatabaseOperations("db_BookStore");
            sellingId = -1;
            customerId = _customerId;
            PaymentType = _paymentType;
        }

        public string PrintProducts() //shows the items currently in the cart
        {
            string result = "";
            foreach (ItemToPurchase item in Products)
            {
                result += "Adı: " + item.Product.getProductName() 
                        + "\nFiyatı: " + item.Product.getProductPrice() 
                        + "\nStok: " + item.Product.Stock 
                        + "\nEklenen: " + item.Quantity 
                        + "\n--------------------------------------------------\n";
            }
            return result;
        }

        public void AddProduct(ItemToPurchase item) //add an item to the shopping cart
        {
            if (!Products.Contains(item))
            {
                Products.Add(item);
            }
            else
            {
                int index = Products.IndexOf(item);
                ((ItemToPurchase)Products[index]).Quantity += item.Quantity;
            }
            paymentAmount += (item.Product.Price) * (item.Quantity);
        }

        public void RemoveProduct(ItemToPurchase item) //remove an item from the shopping card
        {
            if (Products.Contains(item))
            {
                Products.Remove(item);
                paymentAmount -= (item.Product.Price) * (item.Quantity);
            }
        }

        public void DecreaseProductCount(int index, int newCount)
        {
            int temp = ((ItemToPurchase)Products[index]).Quantity;
            ((ItemToPurchase)Products[index]).Quantity = newCount;
            temp-= newCount;
            paymentAmount -= (((ItemToPurchase)Products[index]).Product.Price) * (temp);
        }

        public void PlaceOrder(Customer _user,bool Mail,bool SMS, string address = "",string Phone ="") //perform the payment for the items in the cart and send invoice to custumer’s email.
        {
            if (sellingId > 0)
            {
                foreach (ItemToPurchase item in Products)
                {
                    Db.I(@"insert into tbl_productSelling (Selling_ID,Product_ID,Quantity) 
                                    values("+sellingId+","+item.Product.ID+","+item.Quantity+")");
                    Db.UD("update tbl_products set " +
                        "Stock=" + (item.Product.Stock - item.Quantity) + ", " +
                        "SoldCount=" + (item.Product.SoldCount + item.Quantity) + " " +
                        "where id=" + item.Product.ID);
                }
            }
            if(Mail)
                SendInvoicebyEmail(_user,address);
            if (SMS)
                SendInvoicebySMS(_user, address, Phone);
        }

        public void CancelOrder() //cancel the order
        {
            if (sellingId <= 0)
                return;
            Db.UD("Update tbl_selling set statu=0 where id="+sellingId);
            
        }

        private void SendInvoicebySMS(Customer user, string address,string Phone) //send Invoice by SMS
        {

        }

        private void SendInvoicebyEmail(Customer user, string address) //send Invoice by Email
        {
            BaseFont myFont = BaseFont.CreateFont(@"C:\windows\fonts\arial.ttf", "windows-1254", BaseFont.EMBEDDED);
            Font fontNormal = new Font(myFont);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            PdfWriter.GetInstance(doc, new FileStream("Invoice.pdf", FileMode.Create));
            doc.Open();
            Paragraph temp = new Paragraph("X MAĞAZASI", fontNormal);
            temp.Alignment = Element.ALIGN_CENTER;
            doc.Add(temp);
            if(DateTime.Now.Day<10)
                temp = new Paragraph("Tarih: 0"+DateTime.Now.ToShortDateString(),fontNormal);
            else
                temp = new Paragraph("Tarih: " + DateTime.Now.ToShortDateString(), fontNormal);
            temp.Alignment = Element.ALIGN_CENTER;
            doc.Add(temp);

            temp = new Paragraph("SiparişID: "+Hash.HashID(sellingId.ToString()), fontNormal);
            temp.Alignment = Element.ALIGN_CENTER;
            doc.Add(temp);

            temp = new Paragraph("\nAlıcı Bilgileri", fontNormal);
            temp.IndentationLeft = 90;
            doc.Add(temp);

            //DataTable dt = Db.Select("select use");
            temp = new Paragraph("Adı: " +user.Name+" "+user.LastName, fontNormal);
            temp.IndentationLeft=90;
            doc.Add(temp);

            temp = new Paragraph("Mail: " +user.Email, fontNormal);
            temp.IndentationLeft = 90;
            doc.Add(temp);
            if(address=="")
                temp = new Paragraph("Adres: " +user.Address, fontNormal);
            else
                temp = new Paragraph("Adres: " + address, fontNormal);
            temp.IndentationLeft = 90;
            doc.Add(temp);

            temp = new Paragraph("\nÜrünler\n\n", fontNormal);
            temp.IndentationLeft = 90;
            doc.Add(temp);
            PdfPTable productTemp = new PdfPTable(3);

            PdfPCell cell = new PdfPCell(new Paragraph("Adı",fontNormal));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            productTemp.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Miktarı", fontNormal));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            productTemp.AddCell(cell);

            cell = new PdfPCell(new Paragraph("Fiyatı", fontNormal));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            productTemp.AddCell(cell);

            foreach (ItemToPurchase item in Products)
            {
                cell = new PdfPCell(new Paragraph( item.Product.Name, fontNormal));
                cell.HorizontalAlignment=Element.ALIGN_CENTER;
                productTemp.AddCell(cell);
                
                cell = new PdfPCell(new Paragraph(item.Quantity.ToString(), fontNormal));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                productTemp.AddCell(cell);

                
                cell = new PdfPCell(new Paragraph(item.Product.Price.ToString(), fontNormal));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                productTemp.AddCell(cell);
            }

            doc.Add(productTemp);
            temp = new Paragraph("Ara Toplam: "+paymentAmount+"₺", fontNormal);
            temp.IndentationRight = 90;
            temp.Alignment = Element.ALIGN_RIGHT;
            doc.Add(temp);

            temp = new Paragraph("Kargo: 6₺", fontNormal);
            temp.IndentationRight = 90;
            temp.Alignment = Element.ALIGN_RIGHT;
            doc.Add(temp);

            temp = new Paragraph("Toplam: " + (paymentAmount + 6).ToString() + "₺", fontNormal);
            temp.IndentationRight = 90;
            temp.Alignment = Element.ALIGN_RIGHT;
            doc.Add(temp);


            temp = new Paragraph("Alışverişte bizi tercih ettiğiniz için teşekkür ederiz. ", fontNormal);
            temp.Alignment = Element.ALIGN_CENTER;
            doc.Add(temp);
            doc.Close();
            Network_.MailSender(user.Email, "Fatura", "X Mağazası\nBookStore'dan aldığınız ürünün faturası ektedir. \nİyi günler dileriz.", "Invoice.pdf");
        }

        public void Clear()
        {
            sellingId = -1;
            paymentType = 1;
            paymentAmount = 0;
            Products.Clear();
        }
    }
}