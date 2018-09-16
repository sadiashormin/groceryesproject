using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using grocery2;

namespace grocery2.Controllers
{
    public class ClerksController : Controller
    {
        private groceryEntities db = new groceryEntities();

        // GET: Clerks
        public ActionResult Index()
        {
            return View(db.Clerks.ToList());
        }

        // GET: Clerks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clerk clerk = db.Clerks.Find(id);
            if (clerk == null)
            {
                return HttpNotFound();
            }
            return View(clerk);
        }

        // GET: Clerks/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["type"] = null;
            //return Login(new Clerk());
            return RedirectToAction("Login", "Clerks", new { });
        }
            // GET: Clerks/Create
            public ActionResult Login([Bind(Include = "Email,Password")] Clerk clerk)
        {
           


            if (clerk.Email != null || clerk.Password != null) {
                if (clerk.Email == "admin" || clerk.Password == "admin")
                {
                    Session["type"] = "admin";
                }
                else {
                    Clerk matchedClerk = db.Clerks.FirstOrDefault(a => a.Email == clerk.Email);

                    if (matchedClerk == null)
                    {
                        ModelState.AddModelError(string.Empty, "No user found with this email address");
                        //return HttpNotFound();
                    }
                    else
                    {
                        if (matchedClerk.Password != clerk.Password)
                        {
                            ModelState.AddModelError(string.Empty, "Email address and password don't match");
                        }
                        else
                        {
                            Session["type"] = "clerk";
                        }
                    }
                }
                   
            }
            if (Session["type"] != null) {
                return RedirectToAction("Index", "Home", new { });
            }
           
            return View();
        }

        // POST: Clerks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password")] Clerk clerk)
        {
            if (ModelState.IsValid)
            {
                db.Clerks.Add(clerk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clerk);
        }

        // GET: Clerks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clerk clerk = db.Clerks.Find(id);
            if (clerk == null)
            {
                return HttpNotFound();
            }
            return View(clerk);
        }

        // POST: Clerks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Password")] Clerk clerk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clerk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clerk);
        }

        // GET: Clerks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clerk clerk = db.Clerks.Find(id);
            if (clerk == null)
            {
                return HttpNotFound();
            }
            return View(clerk);
        }

        // POST: Clerks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clerk clerk = db.Clerks.Find(id);
            db.Clerks.Remove(clerk);
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
