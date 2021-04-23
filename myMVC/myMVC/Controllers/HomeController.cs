using Microsoft.AspNetCore.Mvc;
using myMVC.Data.Interfaces;
using myMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Controllers
{
    public class HomeController : Controller
    {
        private IAllCars carRrepository;
        public HomeController(IAllCars rep)
        {
            carRrepository = rep;
        }
        public IActionResult Index()
        {
            var cars = new HomeViewModel
            {
                Cars = carRrepository.FavouriteCars
            };
            return View(cars);
        }
    }
}
