using Microsoft.AspNetCore.Mvc;
using myMVC.Data.Interfaces;
using myMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly Cart cart;
        public OrderController(IAllOrders allOrders, Cart c)
        {
            _allOrders = allOrders;
            cart = c;
        }
        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut(Order order)
        {
            cart.ListCartItems = cart.GetItems().Result;
            if (cart.ListCartItems.Count == 0)
            {
                ModelState.AddModelError("", "You should add a goods");
            }
            if (ModelState.IsValid)
            {
                await _allOrders.CreateOrderAsync(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Order completed";
            return View();
        }
    }
}
