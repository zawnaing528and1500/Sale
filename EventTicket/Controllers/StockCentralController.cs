using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventTicket.Controllers
{
    public class StockCentralController : Controller
    {
        // GET: StockCentral
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowBranch()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }

        #region Lack Packing Product
        public ActionResult ShowLackPackingProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ViewLackPackingProduct()
        {
            int ShopID = Convert.ToInt32(Request.QueryString["ShopID"]);
            ViewBag.ShopID = ShopID;
            return View();
        }
        #endregion

        #region Expire Packing Product
        public ActionResult ShowExpiryPackingProduct()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ViewExpiryPackingProduct()
        {
            int ShopID = Convert.ToInt32(Request.QueryString["ShopID"]);
            ViewBag.ShopID = ShopID;
            return View();
        }
        #endregion

        public ActionResult ShowAggreement()
        {
            if (Session["CurrentUserID"] == null)
            {
                Response.Redirect("~/StockLogin/LoginForm");
            }
            return View();
        }
        public ActionResult ShowUsernamePassword()
        {
            int ShopID = Convert.ToInt32(Request.QueryString["ShopID"]);
            ViewBag.ShopID = ShopID;
            return View();
        }
    }
}