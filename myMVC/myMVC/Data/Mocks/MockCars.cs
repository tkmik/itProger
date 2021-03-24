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
                        Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.drive.ru%2Fnews%2Ftesla%2F5ea6dd8dec05c41134000021.html&psig=AOvVaw2TSG3cJ9Fa8cx8hQ7-zAwb&ust=1616450688239000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCKiOwZqywu8CFQAAAAAdAAAAABAD", 
                        Price = 45000, 
                        IsFavourite = true, 
                        Available = true, 
                        Category = _categoryCars.GetAllCatogories.First() 
                    },
                    new Car{
                        Name = "BMV",
                        ShortDescription = "F",
                        LongDescription = " a fast car",
                        Image = "https://www.google.com/url?sa=i&url=http%3A%2F%2Fwww.motorpage.ru%2FBMW%2F5series%2Flast%2F&psig=AOvVaw0cpr3RyoXqG-KsSTt4T3Yo&ust=1616450783409000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCLjNtsmywu8CFQAAAAAdAAAAABAD",
                        Price = 105000,
                        IsFavourite = false,
                        Available = true,
                        Category = _categoryCars.GetAllCatogories.Last() 
                    }
                };
            }
        }
        public IEnumerable<Car> FavouriteCars { get; set; }

        public Car GetCarById(int index)
        {
            throw new NotImplementedException();
        }
    }
}
