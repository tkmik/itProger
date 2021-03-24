using myMVC.Data.Interfaces;
using myMVC.Data.Models;
using System.Collections.Generic;

namespace myMVC.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> GetAllCatogories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ CategoryName = "Electro cars", Description = "modern, using electricity" },
                    new Category{ CategoryName = "Classic cars", Description = "old, using petrol"  }
                };
            }
        }
    }
}
