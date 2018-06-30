using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingSIte.Models;
using ShoppingSite.Models;
using System.Web.Routing;

namespace ShoppingSIte.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private ProductInventoryDb db = new ProductInventoryDb();

        // GET: Carts
        [ActionName("Index")]
        public ActionResult ShowCart()
        {
            ViewBag.TotalItems = new CartItems().TotalItems(User.Identity.Name);
            var carts = db.Carts.Where(C => C.EmailId == User.Identity.Name);
            return View(carts.ToList());
        }


        public ActionResult AddToCart(int ProductId)
        {
            Cart cart = new Cart() { ProductId = ProductId, EmailId = User.Identity.Name };

            db.Carts.Add(cart);
            db.SaveChanges();

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", cart.ProductId);
            return RedirectToAction("Details", new RouteValueDictionary(
    new { controller = "Products", action = "Details", id = ProductId }));

        }

       
        [ActionName("Delete")]
        public ActionResult RemoveFromCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }

            db.Carts.Remove(cart);
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
