using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ShoppingSite.Models;
using ShoppingSIte.Models;

namespace ShoppingSite.Controllers
{
    [Authorize]
    public class ProductReviewsController : Controller
    {
        private ProductInventoryDb _db = new ProductInventoryDb();


        public ActionResult Create(int ProductId)
        {
            ViewBag.ProductId = ProductId;
            ViewBag.IsCustomer = new UserRoles().CheckUserInRole(User.Identity.GetUserId(), "Customer");
            ViewBag.TotalItems = new CartItems().TotalItems(User.Identity.Name);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ReviewerName,Rating,Comments,ProductId")] ProductReview productReview, int productId)
        {
            if (ModelState.IsValid)
            {
                _db.ProductReviews.Add(productReview);
                _db.SaveChanges();
                ViewBag.TotalItems = new CartItems().TotalItems(User.Identity.Name);
                return RedirectToAction("Details", "Products", new { id = productId });
            }

            return View(productReview);
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
