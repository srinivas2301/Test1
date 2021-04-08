using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test1.Models;

namespace Test1.Controllers
{
    public class LoginsController : Controller
    {
        private Day9DBEntities db = new Day9DBEntities();

        // GET: Logins
        public ActionResult Index()
        {
            return View(db.Leaves.Where(l => l.status == "Pending").ToList());
        }

        // GET: Logins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // GET: Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login login)
        {
            //if (ModelState.IsValid)
            //{
            //    Login l = db.Logins.Where(e => e.UserName.Equals(login.UserName) && e.PassWord.Equals(login.PassWord)&&e.Designation.Equals(login.Designation)).FirstOrDefault();
            //    if (l != null)
            //        //if(l.Designation=="manager")
            //        //{
            //        //    return RedirectToAction("Edit");
            //        //}
            //       return RedirectToAction("welocome");
            //}
            //else
            //    ViewBag.errormessage = "not valid";
            //    return View(login);
            var result = (from e in db.Logins
                          where e.UserName == login.UserName && e.PassWord == login.PassWord
                          select e).FirstOrDefault();
            if (result != null && result.Designation.Equals("Employee"))
            {

                return this.RedirectToAction("Create", "Leaves");

            }
            else if (result != null && result.Designation.Equals("Manager"))
            {
                var pendingleaves = from e in db.Leaves select e;
                return RedirectToAction("Index", "Leaves");
              
            }

            else

                ViewBag.ErrorMessage = "InvalidUser";

            return View();

        }

        // GET: Logins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,PassWord,Designation")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(login).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(login);
        }

        // GET: Logins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Login login = db.Logins.Find(id);
            if (login == null)
            {
                return HttpNotFound();
            }
            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Login login = db.Logins.Find(id);
            db.Logins.Remove(login);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public  ActionResult Welocome()
        {
            return View("Leave");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
