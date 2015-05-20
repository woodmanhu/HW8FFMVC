using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QiwenFFMVC.Models;

namespace QiwenFFMVC
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            return View(db.FFUsers.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FFUser fFUser = db.FFUsers.Find(id);
            if (fFUser == null)
            {
                return HttpNotFound();
            }
            return View(fFUser);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Username,lat,lon,ImageUrl")] FFUser fFUser)
        {
            if (ModelState.IsValid)
            {
                db.FFUsers.Add(fFUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fFUser);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FFUser fFUser = db.FFUsers.Find(id);
            if (fFUser == null)
            {
                return HttpNotFound();
            }
            return View(fFUser);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Username,lat,lon,ImageUrl")] FFUser fFUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fFUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fFUser);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FFUser fFUser = db.FFUsers.Find(id);
            if (fFUser == null)
            {
                return HttpNotFound();
            }
            return View(fFUser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FFUser fFUser = db.FFUsers.Find(id);
            db.FFUsers.Remove(fFUser);
            db.SaveChanges();
            return RedirectToAction("Index");
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
