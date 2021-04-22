using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public uint Price { get; set; }
        public string CartId { get; set; }
    }
}
