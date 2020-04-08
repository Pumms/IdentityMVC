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
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You must Login First');window.location.href = '/Auth/Login';</script>");
            }
        }

        public ActionResult About()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You must Login First');window.location.href = '/Auth/Login';</script>");
            }
        }

        public ActionResult Contact()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Message = "Your application description page.";
                return View();
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>alert('You must Login First');window.location.href = '/Auth/Login';</script>");
            }
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}