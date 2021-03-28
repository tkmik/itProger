using myMVC.Data.Interfaces;
using myMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private AppDbContext appDbContext;

        public CategoryRepository(AppDbContext context)
        {
            appDbContext = context;
        }
        public IEnumerable<Category> GetAllCatogories
        {
            get
            {
                return appDbContext.Categories;
            }
        }
    }
}
