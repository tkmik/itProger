using myMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
    }
}
