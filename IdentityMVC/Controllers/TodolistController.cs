using IdentityMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace IdentityMVC.Controllers
{
    [Authorize]
    public class TodolistController : Controller
    {
        ApplicationDbContext con = new ApplicationDbContext();
        // GET: Todolist
        public ActionResult Index()
        {
            List<Todolist> TdList = new List<Todolist>();

            foreach (Todolist data in con.Todolist.ToList())
            {
                if (data.ApplicationUserId == System.Web.HttpContext.Current.User.Identity.GetUserId())
                {
                    TdList.Add(data);
                }
            }

            return View(TdList.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Todolist todolist)
        {
            todolist.ApplicationUserId = User.Identity.GetUserId();
            con.Todolist.Add(todolist);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(con.Todolist.Where(s => s.Id == id).FirstOrDefault());
        }

        public ActionResult Delete(int id)
        {
            return View(con.Todolist.Where(s => s.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete(int id, Todolist todolist)
        {
            todolist = con.Todolist.Where(s => s.Id == id).FirstOrDefault();
            con.Todolist.Remove(todolist);
            con.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}