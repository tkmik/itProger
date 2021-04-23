using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public uint Price { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
