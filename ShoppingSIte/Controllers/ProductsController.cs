using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingSite.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using ShoppingSIte.Models;

namespace ShoppingSite.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {

        private ProductInventoryDb _db = new ProductInventoryDb();



        public ActionResult Index()
        {
            ViewBag.TotalItems = new CartItems().TotalItems(User.Identity.Name);
            ViewBag.IsAdmin = new UserRoles().CheckUserInRole(User.Identity.GetUserId(), "Admin");
            return View(_db.Products.ToList());
        }


        public ActionResult Details(int id)
        {

            Product product = _db.Products.Find(id);
            ViewBag.AvgRating = new Reviews().AverageReviews(id);
            ViewBag.IsCustomer = new UserRoles().CheckUserInRole(User.Identity.GetUserId(), "Customer");
            var carts = _db.Carts.Where(C => C.EmailId == User.Identity.Name);

            ViewBag.TotalItems = new CartItems().TotalItems(User.Identity.Name);


            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        public ActionResult Create()
        {
            ViewBag.IsCustomer = new UserRoles().CheckUserInRole(User.Identity.GetUserId(), "Customer");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,ProductDescription,Category,UnitPrice,UnitsInStock")] Product product)
        {
           
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,ProductDescription,Category,UnitPrice,UnitsInStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(product).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search(String searchTerm)

        {
            var model = _db.Products.Where(P => P.ProductName.ToLower().Contains(searchTerm.ToLower()));

            return View("Index", model);

        }
        public ActionResult AutoComplete(String term)
        {
            var model = _db.Products.Where(P => P.ProductName.ToLower().StartsWith(term.ToLower())).Take(10).Select(P => new { P.ProductName });
            return Json(model.Select(o => o.ProductName), JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
