using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using PagedList;
namespace AngkorColor.Controllers
{
    public class HomeController : Controller
    {
        private AngkorColorEcommerceEntities db = new AngkorColorEcommerceEntities();
        public ActionResult Index(int page=1, int pagesize=4)
        {
            List<Category> CatList = db.Categories.ToList();
            List<ProductType> paintType = db.ProductTypes.ToList();
            ViewBag.PaintType = paintType;
            ViewBag.Cat = CatList;
             //var products = db.Products.Take(8).Include(p => p.Brand).Include(p => p.Category);
            var products = db.Products.Include(p => p.Brand).Include(p => p.Category);
            PagedList<Product> model = new PagedList<Product>(products.ToList(), page, pagesize);
            return View(model);
        }
        public ActionResult CateoryList()
        {
            List<Category> CatList = db.Categories.ToList();
            return PartialView(CatList);
        }
        public ActionResult ProByCat(Guid guid,int page = 1, int pagesize = 4)
        {
            List<Category> CatList = db.Categories.ToList();
            ViewBag.Cat = CatList;
            //var products = db.Products.Take(8).Include(p => p.Brand).Include(p => p.Category);
            var products = db.Products.Include(p => p.Brand).Include(p => p.Category).Where(pro => pro.Category.ID == guid);
            PagedList<Product> model = new PagedList<Product>(products.ToList(), page, pagesize);
            return View(model);
        }
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
        //public ActionResult Detail()
        //{
        //    List<Category> CatList = db.Categories.ToList();
        //    ViewBag.Cat = CatList;
        //    var products = db.Products.Take(16).Include(p => p.Brand).Include(p => p.Category);
        //    return View(products.ToList());
        //}
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public PartialViewResult ListByCat()
        {
            List<Product> CatList = db.Products.Take(2).ToList();
            ViewBag.Cat = CatList;
            return PartialView("ListByCat",CatList);
            
        }
    }
}