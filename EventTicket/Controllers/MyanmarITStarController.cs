using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventTicket.App_Code;
using System.Data;

namespace EventTicket.Controllers
{
    public class MyanmarITStarController : Controller
    {
        StockDBBase stock = new StockDBBase();
        // GET: MyanmarITStar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GenerateBarcode()
        {
            DataTable Product = stock.getAllByQuery("select * from Product where ShopID=" + 3);
            foreach(DataRow rows in Product.Rows)
            {
                int ID = Convert.ToInt32(rows["ID"]);
                string Barcode = GetBarCode();
                stock.ChangeByQuery("update Product set Barcode='"+Barcode+"' where ID="+ID);
            }
            return View();
        } 
        public string GetBarCode()
        {
            Random Random = new Random();
            int Random1 = Random.Next(273639, 917465); int Random2 = Random.Next(273639, 917465);
            string Barcode = Random1.ToString() + Random2.ToString();
            if(stock.CheckByQuery("select * from Product where Barcode='" + Barcode + "'"))
            {
                GetBarCode();
            }
                return Barcode;
        }
    }
}