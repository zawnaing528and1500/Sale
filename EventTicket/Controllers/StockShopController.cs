using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventTicket.App_Code;
using System.Data;

namespace EventTicket.Controllers
{
    public class StockShopController : Controller
    {
        StockDBBase stock = new StockDBBase();

        // GET: StockShop
        public ActionResult Index()
        {
            return View();
        }
         
        #region Pack Product
        public ActionResult NewProductPackingForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ProcessNewProductPackingForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            string Name = Request.Form["Name"];
            int Quantity = Convert.ToInt32(Request.Form["Quantity"]);
            int Minimum = Convert.ToInt32(Request.Form["Minimium"]);
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            string ExpiryDate = Request.Form["ExpiryDate"];
            int CostPrice = Convert.ToInt32(Request.Form["CostPrice"]);
            int SellingPrice = Convert.ToInt32(Request.Form["SellingPrice"]);
            string Barcode = Request.Form["Barcode"];
            if (ExpiryDate == null)
            {
                stock.ChangeByQuery("insert into Product values(" + ShopID + ",N'" + Name + "'," + Quantity + "," + Minimum + ",'True','" + DateTime.Now.ToString("MM.dd.yyyy") + "',NULL,"+CostPrice+","+SellingPrice+",'"+Barcode+"')");

            }
            else
            {
                stock.ChangeByQuery("insert into Product values(" + ShopID + ",N'" + Name + "'," + Quantity + "," + Minimum + ",'True','" + DateTime.Now.ToString("MM.dd.yyyy") + "','"+ExpiryDate+"',"+CostPrice+","+SellingPrice+",'"+Barcode+"')");
            }
            return RedirectToAction("NewProductPackingForm", "StockShop");
        }
        public ActionResult DeleteProductPacking()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            stock.ChangeByQuery("delete from InvoiceLine where ProductID=" + ID + " and ShopID=" + ShopID);
            stock.ChangeByQuery("delete from Product where ID=" + ID + " and ShopID=" + ShopID);
            return RedirectToAction("NewProductPackingForm", "StockShop");
        }
        public ActionResult EditProductPackingForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            ViewBag.ID = ID;
            return View();
        }
        public ActionResult ProcessEditProductPackingForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ProductID = Convert.ToInt32(Request.Form["ProductID"]);
            string Name = Request.Form["Name"];
            int Quantity = Convert.ToInt32(Request.Form["Quantity"]);
            int Minimum = Convert.ToInt32(Request.Form["Minimum"]);
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            string ExpiryDate = Request.Form["ExpiryDate"];
            int CostPrice = Convert.ToInt32(Request.Form["CostPrice"]);
            int SellingPrice = Convert.ToInt32(Request.Form["SellingPrice"]);
            string Barcode = Request.Form["Barcode"];
            if (ExpiryDate == null)
            {
               stock.ChangeByQuery("update Product set Name= N'"+Name+"', Quantity="+Quantity+" , Minimum ="+Minimum+" , ExpiryDate = null, CostPrice = "+CostPrice+", SellingPrice = "+SellingPrice+",Barcode ='"+Barcode+"' where ID="+ProductID);
            }
            else
            {
                stock.ChangeByQuery("update Product set Name= N'" + Name + "', Quantity=" + Quantity + " , Minimum =" + Minimum + " , ExpiryDate = '"+ExpiryDate+"', CostPrice = " + CostPrice + ", SellingPrice = " + SellingPrice + ",Barcode ='" + Barcode + "' where ID=" + ProductID);
            }
            return RedirectToAction("AllPackingProduct", "StockShop");
        }
        #endregion

        #region Unit Product
        public ActionResult NewProductUnitForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ProcessNewProductUnitForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            string Name = Request.Form["Name"];
            int Quantity = Convert.ToInt32(Request.Form["Quantity"]);
            int Minimum = Convert.ToInt32(Request.Form["Minimium"]);
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int CostPrice = Convert.ToInt32(Request.Form["CostPrice"]);
            int SellingPrice = Convert.ToInt32(Request.Form["SellingPrice"]);
            string Barcode = Request.Form["Barcode"];

            string ExpiryDate = Request.Form["ExpiryDate"];
            if (ExpiryDate == null)
            {
                stock.ChangeByQuery("insert into Product values(" + ShopID + ",N'" + Name + "'," + Quantity + "," + Minimum + ",'False','" + DateTime.Now.ToString("MM.dd.yyyy") + "',NULL," + CostPrice + "," + SellingPrice + ",'" + Barcode + "')");

            }
            else
            {
                stock.ChangeByQuery("insert into Product values(" + ShopID + ",N'" + Name + "'," + Quantity + "," + Minimum + ",'False','" + DateTime.Now.ToString("MM.dd.yyyy") + "','" + ExpiryDate + "'," + CostPrice + "," + SellingPrice + ",'" + Barcode + "')");
            }
            return RedirectToAction("NewProductUnitForm", "StockShop");
        }
        public ActionResult DeleteProductUnit()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            stock.ChangeByQuery("delete from InvoiceLine where ProductID=" + ID + " and ShopID=" + ShopID);
            stock.ChangeByQuery("delete from Product where ID=" + ID + " and ShopID=" + ShopID);
            return RedirectToAction("NewProductUnitForm", "StockShop");
        }
        public ActionResult EditProductUnitForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            ViewBag.ID = ID;
            return View();
        }
        public ActionResult ProcessEditProductUnitForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ProductID = Convert.ToInt32(Request.Form["ProductID"]);
            string Name = Request.Form["Name"];
            int Quantity = Convert.ToInt32(Request.Form["Quantity"]);
            int Minimum = Convert.ToInt32(Request.Form["Minimum"]);
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            string ExpiryDate = Request.Form["ExpiryDate"];
            int CostPrice = Convert.ToInt32(Request.Form["CostPrice"]);
            int SellingPrice = Convert.ToInt32(Request.Form["SellingPrice"]);
            string Barcode = Request.Form["Barcode"];
            if (ExpiryDate == null)
            {
                stock.ChangeByQuery("update Product set Name= N'" + Name + "', Quantity=" + Quantity + " , Minimum =" + Minimum + " , ExpiryDate = null, CostPrice = " + CostPrice + ", SellingPrice = " + SellingPrice + ",Barcode ='" + Barcode + "' where ID=" + ProductID);
            }
            else
            {
                stock.ChangeByQuery("update Product set Name= N'" + Name + "', Quantity=" + Quantity + " , Minimum =" + Minimum + " , ExpiryDate = '" + ExpiryDate + "', CostPrice = " + CostPrice + ", SellingPrice = " + SellingPrice + ",Barcode ='" + Barcode + "' where ID=" + ProductID);
            }
            return RedirectToAction("AllUnitProduct", "StockShop");
        }
        #endregion


        #region Re Pack Product

        public ActionResult ReProductPackingForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public  ActionResult ProcessReProductPackingForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ID = Convert.ToInt32(Request.Form["ID"]);
            int Quantity = Convert.ToInt32(Request.Form["Quantity"]);
            string ExpiryDate = Request.Form["ExpiryDate"];
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            stock.ChangeByQuery("update Product set Quantity=Quantity+" + Quantity+", ExpiryDate = '"+ExpiryDate+"',Date='"+ DateTime.Now.ToString("MM.dd.yyyy") + "' where ID="+ID+" and ShopID="+ShopID);
            return RedirectToAction("ReProductPackingForm", "StockShop");
        }

        #endregion

        #region Re Unit Product
        public ActionResult ReProductUnitForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ProcessReProductUnitForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ID = Convert.ToInt32(Request.Form["ID"]);
            int Quantity = Convert.ToInt32(Request.Form["Quantity"]);
            string ExpiryDate = Request.Form["ExpiryDate"];
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            stock.ChangeByQuery("update Product set Quantity=Quantity+" + Quantity + ", ExpiryDate = '" + ExpiryDate + "',Date='" + DateTime.Now.ToString("MM.dd.yyyy") + "' where ID=" + ID + " and ShopID=" + ShopID);
            return RedirectToAction("ReProductUnitForm", "StockShop");
        }
        #endregion


        #region Out of Packing Product
        public ActionResult OutProductPackingForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ProcessOutProductPackingForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ID = Convert.ToInt32(Request.Form["ID"]);
            int OutQuantity = Convert.ToInt32(Request.Form["Quantity"]);
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            string Status = Request.Form["Status"];
            int TotalQuantity = stock.getIntByQuery("select * from Product where ID=" + ID, "Quantity");
            if (OutQuantity <= TotalQuantity)
            {
                stock.ChangeByQuery("update Product set Quantity=Quantity-" + OutQuantity + " where ID=" + ID + " and ShopID=" + ShopID);
                //For Transfer and Damage Product
                stock.ChangeByQuery("insert into WastedProduct values(" + ID + "," + OutQuantity + ",'" + Status + "','" + DateTime.Now.ToString("MM.dd.yyyy") + "'," + ShopID + ")");
                string Name = stock.getStringByQuery("select * from Product where ID="+ID, "Name");
                int LeftQuantity = TotalQuantity - OutQuantity;
                Session["OutInfo"] = "["+Name+"] "+OutQuantity+ " (ပါကင္​) ထုတ္​ၿပီးပါၿပီ။ လက္​က်န္​မွာ "+LeftQuantity+ " (ပါကင္)​ျဖစ္​သည္​";
            }
            else
            {
                Session["OutInfo"] = "ပစၥည္​း လက္​က်န္​ မလံု​ေလာက္ပါ။​​";
            }
            return RedirectToAction("OutProductPackingForm", "StockShop");
        }
        #endregion

        #region Out of Unit Product
        public ActionResult OutProductUnitForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ProcessOutProductUnitForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ID = Convert.ToInt32(Request.Form["ID"]);
            int OutQuantity = Convert.ToInt32(Request.Form["Quantity"]);
            string Status = Request.Form["Status"];
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int TotalQuantity = stock.getIntByQuery("select * from Product where ID=" + ID, "Quantity");
            if (OutQuantity <= TotalQuantity)
            {
                stock.ChangeByQuery("update Product set Quantity=Quantity-" + OutQuantity + " where ID=" + ID + " and ShopID=" + ShopID);
                string Name = stock.getStringByQuery("select * from Product where ID=" + ID, "Name");
                //For Transfer and Damage Product
                stock.ChangeByQuery("insert into WastedProduct values("+ID+","+OutQuantity+",'"+Status+"','"+ DateTime.Now.ToString("MM.dd.yyyy") + "',"+ShopID+")");
                int LeftQuantity = TotalQuantity - OutQuantity;
                Session["OutInfo"] = "["+Name + " ] " + OutQuantity + " (ခု) ထုတ္​ၿပီးပါၿပီ။ လက္​က်န္​မွာ " + LeftQuantity + " (ခု) ျဖစ္​သည္​​";
            }
            else
            {
                Session["OutInfo"] = "ပစၥည္​း လက္​က်န္​ မလံု​ေလာက္ပါ။​​";
            }
            return RedirectToAction("OutProductUnitForm", "StockShop");
        }
        #endregion

        #region Lack both Packing and Unit Product
        public ActionResult LackPackingProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult LackUnitProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        #endregion

        #region See all packing product
        public ActionResult AllPackingProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult DeletePackingProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            stock.ChangeByQuery("delete from InvoiceLine where ProductID=" + ID + " and ShopID=" + ShopID);
            stock.ChangeByQuery("delete from Product where ID=" + ID + " and ShopID=" + ShopID);
            return RedirectToAction("AllPackingProduct", "StockShop");
        }
        #endregion

        #region See all Unit Product
        public ActionResult AllUnitProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult DeleteUnitProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            stock.ChangeByQuery("delete from InvoiceLine where ProductID=" + ID + " and ShopID=" + ShopID);
            stock.ChangeByQuery("delete from Product where ID=" + ID + " and ShopID=" + ShopID);
            return RedirectToAction("AllUnitProduct", "StockShop");
        }
        #endregion

        #region Expiry Date Product
        public ActionResult ExpiryPackingProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ExpiryUnitProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        #endregion

        #region Sale Module

        #region Admin Sale Module
        public ActionResult SaleForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ProcessSaleForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            try
            {
                //< input type = "hidden" id = "HSelectedProductID" name = "SelectedProductID" />
                //     < input type = "hidden" id = "HSelectedProductQuantity" name = "SelectedProductQuantity" />
                //          < input type = "hidden" id = "HPartialTotal" name = "PartialTotal" />
                //               < input type = "hidden" id = "HTotalCost" name = "TotalCost" />

                int ShopID = Convert.ToInt32(Session["CurrentUserID"]);

                int TotalCost = Convert.ToInt32(Request.Form["TotalCost"]);
                String selectedProductID = Request.Form["SelectedProductID"];
                String selectedProductQuantity = Request.Form["SelectedProductQuantity"];
                String partialTotal = Request.Form["PartialTotal"];
                int DeliveryFee = 0;

                //Removing Comma and put to array
                string[] separater = { "," };
                string[] SelectedProductID = selectedProductID.Split(separater, StringSplitOptions.RemoveEmptyEntries);
                string[] SelectedProductQuantity = selectedProductQuantity.Split(separater, StringSplitOptions.RemoveEmptyEntries);
                string[] PartialTotal = partialTotal.Split(separater, StringSplitOptions.RemoveEmptyEntries);

                if (SelectedProductID.Length > 0)
                {
                    //Check For Online Shopping
                    if (stock.CheckByQuery("select * from Shop where ID=" + ShopID + " and OnlineShopping='True'"))
                    {
                        string Name = Request.Form["Name"];
                        string Address = Request.Form["Address"];
                        string Phone = Request.Form["Phone"];
                        string Township = Request.Form["Township"];

                        if (Request.Form["DeliveryFee"] == null || string.IsNullOrWhiteSpace(Request.Form["DeliveryFee"]))
                        {
                        }
                        else
                        {
                            DeliveryFee = Convert.ToInt32(Request.Form["DeliveryFee"]);
                        }


                        //Insert into Invoice Table
                        stock.ChangeByQuery("insert into Invoice values(" + ShopID + "," + TotalCost + ",N'" + Name + "',N'" + Address + "',N'" + Phone + "',N'" + Township + "'," + DeliveryFee + ",'" + DateTime.Now + "')");
                        int InvoiceID = stock.getIntByQuery("SELECT * FROM Invoice where ShopID=" + ShopID + " ORDER BY ID ASC", "ID");
                        int i = 0;
                        foreach (var word in SelectedProductID)
                        {
                            int PartialCost = stock.getIntByQuery("select * from Product where ID=" + Convert.ToInt32(SelectedProductID[i]), "CostPrice") * Convert.ToInt32(SelectedProductQuantity[i]);
                            int Profit = Convert.ToInt32(PartialTotal[i]) - PartialCost;
                            //SelectedProductID and Quantity 
                            stock.ChangeByQuery("update Product set Quantity= Quantity-" + Convert.ToInt32(SelectedProductQuantity[i]) + " where ID=" + Convert.ToInt32(SelectedProductID[i]));
                            stock.ChangeByQuery("insert into InvoiceLine values(" + InvoiceID + "," + ShopID + "," + SelectedProductID[i] + "," + SelectedProductQuantity[i] + "," + PartialTotal[i] + "," + Profit + ",'" + DateTime.Now + "')");
                            i++;
                        }
                        ViewBag.InvoiceID = InvoiceID;
                        ViewBag.Name = Name;
                        ViewBag.Address = Address;
                        ViewBag.Phone = Phone;
                        ViewBag.Township = Township;
                        ViewBag.DeliveryFee = DeliveryFee;
                        return View();
                    }
                    else
                    {
                        //Insert into Invoice Table
                        stock.ChangeByQuery("insert into Invoice values(" + ShopID + "," + TotalCost + ",null,null,null,null,null,'" + DateTime.Now + "')");
                        int InvoiceID = stock.getIntByQuery("SELECT * FROM Invoice where ShopID=" + ShopID + " ORDER BY ID ASC", "ID");
                        int i = 0;
                        foreach (var word in SelectedProductID)
                        {
                            int PartialCost = stock.getIntByQuery("select * from Product where ID=" + Convert.ToInt32(SelectedProductID[i]), "CostPrice") * Convert.ToInt32(SelectedProductQuantity[i]);
                            int Profit = Convert.ToInt32(PartialTotal[i]) - PartialCost;
                            //SelectedProductID and Quantity 
                            stock.ChangeByQuery("update Product set Quantity= Quantity-" + Convert.ToInt32(SelectedProductQuantity[i]) + " where ID=" + Convert.ToInt32(SelectedProductID[i]));
                            stock.ChangeByQuery("insert into InvoiceLine values(" + InvoiceID + "," + ShopID + "," + SelectedProductID[i] + "," + SelectedProductQuantity[i] + "," + PartialTotal[i] + "," + Profit + ",'" + DateTime.Now + "')");
                            i++;
                        }

                        return RedirectToAction("SaleForm", "StockShop");
                    }
                }
                else
                {
                    return RedirectToAction("SaleForm", "StockShop");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("SaleForm", "StockShop");
            }
            
        }
        #endregion

        public ActionResult SaleForce()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }

            if (TempData["FromDate"] != null)
            {
                ViewBag.FromDate = TempData["FromDate"].ToString();
                ViewBag.ToDate = TempData["ToDate"].ToString();
            }
            else
            {
                ViewBag.FromDate = null;
                ViewBag.ToDate = null;
            }
            return View();
        }
        public ActionResult ProcessSaleForce()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }

            string FromDate = Request.Form["FromDate"];
            string ToDate = Request.Form["ToDate"];

            TempData["FromDate"] = FromDate;
            TempData["ToDate"] = ToDate;

            return RedirectToAction("SaleForce", "StockShop");
        }
        #endregion

        #region Expense Module

        #region Expense Category
        public ActionResult AddExpenseCategory()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ProcessAddExpenseCategory()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }

            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            string Name = Request.Form["Name"];
            stock.ChangeByQuery("insert into ExpenseCategory values(" + ShopID + ",N'" + Name + "','" + DateTime.Now.ToString("MM.dd.yyyy") + "')");
            return RedirectToAction("AddExpenseCategory", "StockShop");
        }

        public ActionResult DeleteExpenseCategory()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }

            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            stock.ChangeByQuery("delete from Expense where ExpenseCategoryID=" + ID + " and ShopID=" + ShopID);
            stock.ChangeByQuery("delete from ExpenseCategory where ID=" + ID + " and ShopID=" + ShopID);
            return RedirectToAction("AddExpenseCategory", "StockShop");

        }
        public ActionResult ExpenseForce()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }

            if (TempData["FromDate"] != null)
            {
                ViewBag.FromDate = TempData["FromDate"].ToString();
                ViewBag.ToDate = TempData["ToDate"].ToString();
            }
            else
            {
                ViewBag.FromDate = null;
                ViewBag.ToDate = null;
            }
            return View();
        }
        public ActionResult ProcessExpenseForce()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }

            string FromDate = Request.Form["FromDate"];
            string ToDate = Request.Form["ToDate"];

            TempData["FromDate"] = FromDate;
            TempData["ToDate"] = ToDate;

            return RedirectToAction("ExpenseForce", "StockShop");
        }
        #endregion

        #region Expense Line
        public ActionResult AddExpense()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ProcessAddExpense()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            string Name = Request.Form["Name"];
            int ExpenseCategoryID = Convert.ToInt32(Request.Form["ExpenseCategoryID"]);
            int Cost = Convert.ToInt32(Request.Form["Cost"]);
            stock.ChangeByQuery("insert into Expense values("+ShopID+","+ExpenseCategoryID+",N'"+Name+"',"+Cost+",'"+ DateTime.Now.ToString("MM.dd.yyyy") + "')");
            return RedirectToAction("AddExpense", "StockShop");
        }

        public ActionResult DeleteExpense()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }

            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            stock.ChangeByQuery("delete from Expense where ID=" + ID + " and ShopID=" + ShopID);
            return RedirectToAction("AddExpense", "StockShop");

        }
        #endregion


        #endregion

        #region Profit Loss

        public ActionResult ProfitLossForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }

            if (TempData["FromDate"] != null)
            {
                ViewBag.FromDate = TempData["FromDate"].ToString();
                ViewBag.ToDate = TempData["ToDate"].ToString();
            }
            else
            {
                ViewBag.FromDate = null;
                ViewBag.ToDate = null;
            }
            return View();
        }
        public ActionResult ProcessProfitLossForm()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }

            string FromDate = Request.Form["FromDate"];
            string ToDate = Request.Form["ToDate"];

            TempData["FromDate"] = FromDate;
            TempData["ToDate"] = ToDate;

            return RedirectToAction("ProfitLossForm", "StockShop");
        }
        #endregion

        public ActionResult WastedProduct()
        {
            return View();
        }
        public ActionResult DeleteWastedProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            stock.ChangeByQuery("delete from WastedProduct where ID=" + ID + " and ShopID=" + ShopID);
            return RedirectToAction("WastedProduct", "StockShop");
        } 
        public ActionResult SeeInvoice()
        {
            return View();
        }

        public ActionResult ShowInvoiceLine()
        {
            ViewBag.InvoiceID = Request.QueryString["InvoiceID"];
            ViewBag.TotalCost = Request.QueryString["TotalCost"];
            ViewBag.DeliveryFee = Request.QueryString["DeliveryFee"];
            return View();
        }
        public ActionResult SetOnlineShoppingMode()
        {
            return View();
        }
        public ActionResult ProcessSetOnlineShoppingMode()
        {
            int ShopID = Convert.ToInt32(Session["CurrentUserID"]);
            if (stock.CheckByQuery("select * from Shop where ID= "+ShopID+" and OnlineShopping='True'"))
            {
                stock.ChangeByQuery("update Shop set OnlineShopping='False' where ID=" + ShopID);
            }
            else
            {
                stock.ChangeByQuery("update Shop set OnlineShopping='True' where ID=" + ShopID);
            }
            return RedirectToAction("SetOnlineShoppingMode", "StockShop");
        }
        public ActionResult PrintBarcode()
        {
            String Barcode = Request.QueryString["Barcode"];
            ViewBag.Barcode = Barcode;
            return View();
        }
        public ActionResult ShowAggreement()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
    }
}