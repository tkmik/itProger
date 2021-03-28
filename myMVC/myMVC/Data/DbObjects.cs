using Microsoft.Extensions.DependencyInjection;
using myMVC.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace myMVC.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Cars.Any())
            {
                context.Cars.AddRange(new List<Car>
                {
                    new Car{
                        Name = "Tesla",
                        ShortDescription = "S",
                        LongDescription = "a short car",
                        Image = "/img/tesla.jpg",
                        Price = 45000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Electro cars"]
                    },
                    new Car{
                        Name = "BMV",
                        ShortDescription = "F",
                        LongDescription = " a fast car",
                        Image = "/img/bmv.jpg",
                        Price = 105000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Classic cars"]
                    }
                });
            }
            context.SaveChanges();
        }

        private static Dictionary<string, Category> Category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (Category is null)
                {
                    var list = new Category[]
                    {
                         new Category{ CategoryName = "Electro cars", Description = "modern, using electricity" },
                         new Category{ CategoryName = "Classic cars", Description = "old, using petrol"  }
                    };
                    Category = new Dictionary<string, Category>();
                    foreach (var item in list)
                    {
                        Category.Add(item.CategoryName, item);
                    }
                }
                return Category;
            }
        }
    }
}
