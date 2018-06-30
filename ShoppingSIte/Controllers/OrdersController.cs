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
using Microsoft.AspNet.Identity;
using ShoppingSite.Controllers;
using System.Data.Entity.Validation;

namespace ShoppingSIte.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ProductInventoryDb db = new ProductInventoryDb();

        // GET: Orders
        public ActionResult Index()
        {
            ViewBag.TotalItems = new CartItems().TotalItems(User.Identity.Name);
            var orders = db.Orders.Where(O => O.EmailID == User.Identity.Name);
            return View(orders.ToList());
        }

       

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.TotalItems = new CartItems().TotalItems(User.Identity.Name);

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,FirstName,LastName,EmailID,PhoneNumber,CreditCardNumber,ExpireMonth,ExpireYear,SecurityCode")] Order order)
        {
                       
                var orderId = order.OrderId;

                order.EmailID = User.Identity.Name;
                db.Orders.Add(order);
                db.SaveChanges();

                var carts = db.Carts.Where(C => C.EmailId == User.Identity.Name).ToList();

                foreach (Cart cart in carts)
                {

                    db.Carts.Remove(cart);
                    var product = db.Products.Where(P => P.ProductId == cart.ProductId).SingleOrDefault();
                    var units = product.UnitsInStock - 1;
                    product.UnitsInStock = units;
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                ApplicationUser userName = new ApplicationUser() { UserName = User.Identity.Name, Email = User.Identity.Name };
                new EmailServices().Email(userName, "Order" + orderId, "Order has been placed. The order Id is " + orderId);
                ViewBag.TotalItems = new CartItems().TotalItems(User.Identity.Name);
            return View("OrderConfirmation");
                    
            
        }



    }
}
