using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngkorColor;

namespace AngkorColor.Controllers.Admin
{
    public class TypeController : Controller
    {
        private AngkorColorEcommerceEntities db = new AngkorColorEcommerceEntities();

        // GET: /Type/
        public ActionResult Index()
        {
            return View(db.ProductTypes.ToList());
        }

        // GET: /Type/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType producttype = db.ProductTypes.Find(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        // GET: /Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Desc")] ProductType producttype)
        {
            if (ModelState.IsValid)
            {
                producttype.ID = Guid.NewGuid();
                db.ProductTypes.Add(producttype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producttype);
        }

        // GET: /Type/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType producttype = db.ProductTypes.Find(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        // POST: /Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Desc")] ProductType producttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producttype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producttype);
        }

        // GET: /Type/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType producttype = db.ProductTypes.Find(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        // POST: /Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProductType producttype = db.ProductTypes.Find(id);
            db.ProductTypes.Remove(producttype);
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
