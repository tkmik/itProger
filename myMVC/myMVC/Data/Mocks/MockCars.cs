using myMVC.Data.Interfaces;
using myMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> AllCars { 
            get 
            {
                return new List<Car>
                {
                    new Car{ 
                        Name = "Tesla", 
                        ShortDescription = "S",  
                        LongDescription = "a short car", 
                        Image = "/img/tesla.jpg", 
                        Price = 45000, 
                        IsFavourite = true, 
                        Available = true, 
                        Category = _categoryCars.GetAllCatogories.First() 
                    },
                    new Car{
                        Name = "BMV",
                        ShortDescription = "F",
                        LongDescription = " a fast car",
                        Image = "/img/bmv.jpg",
                        Price = 105000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.GetAllCatogories.Last() 
                    }
                };
            }
        }
        public IEnumerable<Car> FavouriteCars { get; set; }

        public Task<Car> GetCarById(int index)
        {
            throw new NotImplementedException();
        }
    }
}
