using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Data.Models
{
    public class Cart
    {
        private readonly AppDbContext appDbContext;
        public Cart(AppDbContext context)
        {
            appDbContext = context;
        }
        public string Id { get; set; }
        public List<CartItem> ListCartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services
                .GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);
            return new Cart(context) { Id = cartId };
        }

        public async Task AddToCart(Car car)
        {
            await appDbContext.CartItems.AddAsync(new CartItem
            {
                CartId = Id,
                Car = car,
                Price = car.Price
            });

            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<CartItem>> GetItems()
        {
            return await appDbContext.CartItems
                .Where(c => c.CartId == Id)
                .Include(s => s.Car)
                .ToListAsync();
        }
        
    }
}
