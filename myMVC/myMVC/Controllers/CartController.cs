using Microsoft.AspNetCore.Mvc;
using myMVC.Data.Interfaces;
using myMVC.Data.Models;
using myMVC.Data.Repository;
using myMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IAllCars carRepository;
        private readonly Cart cart;

        public CartController(IAllCars carRep, Cart c)
        {
            carRepository = carRep;
            cart = c;
        }
        public IActionResult Index()
        {
            var items = cart.GetItems();
            cart.ListCartItems = items.Result;
            var res = new CartViewModel { Cart = cart };

            return View(res);
        }
        public async Task<RedirectToActionResult> AddToCar(int id)
        {
            var item = carRepository.AllCars.FirstOrDefault(i => i.Id == id);
            if (item is not null)
            {
                await cart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
