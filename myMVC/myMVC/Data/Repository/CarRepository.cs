using Microsoft.EntityFrameworkCore;
using myMVC.Data.Interfaces;
using myMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContext appDbContext;
        public CarRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public IEnumerable<Car> AllCars
        {
            get
            { 
               return appDbContext.Cars.Include(c => c.Category); 
            }
        }

        public IEnumerable<Car> FavouriteCars
        {
           get 
           {
               return appDbContext.Cars.Where(f => f.IsFavourite).Include(c => c.Category); 
           }             
        }

        public Car GetCarById(int index)
        {
            return appDbContext.Cars.FirstOrDefault(i => i.Id == index);
        }
    }
}
