using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngkorColor;
using System.Web.Helpers;
using System.IO;
using PagedList;
using System.Text;
using System.Drawing;

namespace AngkorColor.Controllers
{
    public class ProductController : Controller
    {
        private AngkorColorEcommerceEntities db = new AngkorColorEcommerceEntities();

        // GET: /Product/
        public ActionResult Index(int page =1, int pagesize = 10)
        {
            //var products = db.Products.Include(p => p.Brand).Include(p => p.Category);
            //return View(products.ToList());
            List<Product> listPro = db.Products.Include(p => p.Brand).Include(p => p.Category).ToList();
            PagedList<Product> model = new PagedList<Product>(listPro, page, pagesize);
            return View(model); 
        }

        // GET: /Product/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Product/Create
        public ActionResult Create()
        {
            ViewBag.ProductBrand = new SelectList(db.Brands, "ID", "Description");
            ViewBag.ProductCategory = new SelectList(db.Categories, "ID", "Name");
            ViewBag.ProductType = new SelectList(db.ProductTypes, "ID", "Desc");
            return View();
        }
        public ActionResult CreateNewPro()
        {
            return PartialView("~/Views/Product/CreateNewPro.cshtml");
        }
        // POST: /Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,ProductName,ProductCode,ProductDesc,ProductBrand,ProductCategory,Price,DateCreated,DateModified,DateDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                WebImage photo = null;
                var newFileName = "";
                var imagePath = "";               
                    photo = WebImage.GetImageFromRequest();
                    if (photo != null)
                    {
                        newFileName = Guid.NewGuid().ToString() + "_" +
                            Path.GetFileName(photo.FileName);
                        imagePath = @"Content\images\Products\" + newFileName;

                        photo.Save(@"~\" + imagePath);
                    }
                product.ID = Guid.NewGuid();
                product.Picture = newFileName;
                product.DateCreated = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductBrand = new SelectList(db.Brands, "ID", "Description", product.ProductBrand);
            ViewBag.ProductCategory = new SelectList(db.Categories, "ID", "Name", product.ProductCategory);
            ViewBag.ProductType = new SelectList(db.ProductTypes, "ID", "Desc", product.ProductType);
            return View(product);
        }

        // GET: /Product/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductBrand = new SelectList(db.Brands, "ID", "Description", product.ProductBrand);
            ViewBag.ProductCategory = new SelectList(db.Categories, "ID", "Name", product.ProductCategory);
            return View(product);
        }

        // POST: /Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Picture,ProductName,ProductCode,ProductDesc,ProductBrand,ProductCategory,Price,DateCreated,DateModified,DateDeleted")] Product product)
             public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductBrand = new SelectList(db.Brands, "ID", "Description", product.ProductBrand);
            ViewBag.ProductCategory = new SelectList(db.Categories, "ID", "Name", product.ProductCategory);
            return View(product);
        }

        // GET: /Product/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult FetchColors()
        {
            var count = 0;
            var sb = new StringBuilder();
            foreach (var color in Enum.GetNames(typeof(KnownColor)))
	        {
		        var colorValue = ColorTranslator.FromHtml(color);
                var html = string.Format("#{0:X2}{1:X2}{2:X2}",
                    colorValue.R,colorValue.G,colorValue.B);
                sb.AppendFormat("<td bgcolor=\"{0}\">&nbsp;</td>", html);
                if (count < 20)
                {
                    count++;
                }
                else
                {
                    sb.Append("</tr><tr>");
                    count = 0;
                }
	        }
            sb.Append("</tbody></table>");
            return Json(sb.ToString());
        }



    }
}
