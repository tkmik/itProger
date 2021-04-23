using myMVC.Data.Interfaces;
using myMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDbContext appDbContext;
        private readonly Cart cart;
        public OrderRepository(AppDbContext context, Cart c)
        {
            appDbContext = context;
            cart = c;
        }
        public async Task CreateOrderAsync(Order order)
        {
            order.OrderTime = DateTime.Now;
            await appDbContext.Orders.AddAsync(order);
            await appDbContext.SaveChangesAsync();
            order.Id = appDbContext.Orders.Where(
                i => i.Name.Equals(order.Name)
                && i.Surname.Equals(order.Surname)
                && i.Email.Equals(order.Email))
                .FirstOrDefault().Id;
            var items = cart.ListCartItems;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail
                {
                    CarId = item.Car.Id,
                    OrderId = order.Id,
                    Price = item.Car.Price
                };
                await appDbContext.OrdersDetail.AddAsync(orderDetail);
            }
            await appDbContext.SaveChangesAsync();
        }
    }
}
