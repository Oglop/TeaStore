using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaEWebStore.Models;

namespace TeaEWebStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private DatabaseAdapter db = new DatabaseAdapter();
        private const string PromoCode = "FREE";

        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values) 
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                // Check if the payment was valid (if values don't equal promocode.. else save order)
                if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else 
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    // Save the order
                    db.Orders.Add(order);
                    db.SaveChanges();

                    // Process order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
            }
            catch
            {
                // Invalid
                return View();
            }
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = db.Orders.Any(
                order => order.OrderId == id &&
                order.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
