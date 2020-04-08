using IdentityMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityMVC.Controllers
{
    //[AuthorizeRedirect(Roles = "admin")]
    public class SupplierController : Controller
    {
        IdentityMVCEntities con = new IdentityMVCEntities();
        // GET: Supplier
        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                return View(con.Suppliers.ToList());
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>window.location.href = '/Home/AccessDenied';</script>");
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return RedirectToAction("Register", "Auth");
        }

        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                con.Suppliers.Add(supplier);
                con.SaveChanges();
                // TODO: Add insert logic here
                return RedirectToAction("/Supplier/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}