using Microsoft.AspNetCore.Mvc;
using myMVC.Data.Interfaces;
using myMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars AllCars, ICarsCategory CarsCategory)
        {
            _allCars = AllCars;
            _allCategories = CarsCategory;
        }
        public ViewResult GetListCars()
        {
            ViewBag.Title = "Cars";
            CarsListViewModels list = new CarsListViewModels();
            list.AllCars = _allCars.AllCars;
            list.CurrentCategory = "Cars";
            return View(list);
        }
    }
}
