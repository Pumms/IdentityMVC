using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace IdentityMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (Session["login"] != null)
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You must Login First');window.location.href = '/Account/Login';</script>");
            }
        }

        public ActionResult Contact()
        {
            if (Session["login"] != null)
            {
                ViewBag.Message = "Your contact page.";
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You must Login First');window.location.href = '/Account/Login';</script>");
            }
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}