using IdentityMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityMVC.Controllers
{
    [Authorize(Roles = "admin")]
    public class SupplierController : Controller
    {
        IdentityMVCEntities con = new IdentityMVCEntities();
        // GET: Supplier
        public ActionResult Index()
        {
            return View(con.Suppliers.ToList());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return RedirectToAction("Register", "Account");
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