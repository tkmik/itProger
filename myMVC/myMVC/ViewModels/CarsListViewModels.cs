using myMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.ViewModels
{
    public class CarsListViewModels
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string CurrentCategory { get; set; }
    }
}
