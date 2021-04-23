using Microsoft.AspNetCore.Mvc;
using myMVC.Data.Interfaces;
using myMVC.Data.Models;
using myMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Controllers
{
    public class CarsController : Controller
    {
        private IAllCars _allCars;
        private ICarsCategory _allCategories;

        public CarsController(IAllCars AllCars, ICarsCategory CarsCategory)
        {
            _allCars = AllCars;
            _allCategories = CarsCategory;
        }
        [Route("Cars/GetListCars")]
        [Route("Cars/GetListCars/{category}")]
        public IActionResult GetListCars(string category)
        {
            IEnumerable<Car> cars = null;
            string currentCategory = "";
            if (String.IsNullOrWhiteSpace(category))
            {
                cars = _allCars.AllCars.OrderBy(i => i.Id);
                currentCategory = "All cars";
            }
            else
            {
                if (string.Equals("Electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.AllCars
                        .Where(i => i.Category.CategoryName.Equals("Electro"))
                        .OrderBy(i => i.Id);
                    currentCategory = "Electro cars";
                }
                else if (string.Equals("Classic", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.AllCars
                        .Where(i => i.Category.CategoryName.Equals("Classic"))
                        .OrderBy(i => i.Id);
                    currentCategory = "Classic cars";
                }             
            }
            var car = new CarsListViewModel
            {
                AllCars = cars,
                CurrentCategory = currentCategory
            };
            ViewBag.Title = "Cars";
            return View(car);
        }
    }
}
