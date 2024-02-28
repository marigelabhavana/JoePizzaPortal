using JoePizzaPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace JoePizzaPortal.Controllers
{
    public class PizzaController : Controller
    {
        static public List<Pizza> pizzalist = new List<Pizza>() 
        {      
            new Pizza { PizzaId = 1,Type = "Chicken Pizza",Price=80},            
            new Pizza { PizzaId = 2,Type = "Margaritta ",Price=230},            
            new Pizza { PizzaId = 3,Type = "Special Pizaa ",Price=150},
            new Pizza { PizzaId = 4,Type = "Pepporni Pizza",Price=110},            
            new Pizza { PizzaId = 5,Type = "Indi Tandoori Pizza",Price=120},                 
        }; 
        static public List<OrderInfo> orderdetails = new List<OrderInfo>();
        public IActionResult Index()
        {
            return View(pizzalist);
        }
        public IActionResult Cart(int id) 
        { 
            var found = (pizzalist.Find(p => p.PizzaId == id)); 
            TempData["id"] = id; return View(found); 
        }
        [HttpPost] 
        public IActionResult Cart(IFormCollection f) 
        { 
            Random r = new Random(); 
            int id = Convert.ToInt32(TempData["id"]); 
            OrderInfo o = new OrderInfo(); 
            var found = (pizzalist.Find(p => p.PizzaId == id)); 
            o.OrderId = r.Next(100, 999); o.PizzaId = id; 
            o.Price = found.Price; o.Type = found.Type; 
            o.Quantity = Convert.ToInt32(Request.Form["qty"]); 
            o.TotalPrice = o.Price * o.Quantity; orderdetails.Add(o); 
            return RedirectToAction("Checkout"); }
        public IActionResult Checkout() { return View(orderdetails); }
    }
}

