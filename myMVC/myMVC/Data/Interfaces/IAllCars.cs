using myMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> AllCars { get; }
        IEnumerable<Car> FavouriteCars { get; }
        Car GetCarById(int index);
    }
}
