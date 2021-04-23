using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myMVC.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Name")]
        [MinLength(5)]
        [Required(ErrorMessage = "The length of the Name must be at least 5 characters")]
        public string Name { get; set; }
        [Display(Name = "Surname")]
        [MinLength(5)]
        [Required(ErrorMessage = "The length of the Surname must be at least 5 characters")]
        public string Surname { get; set; }
        [Display(Name = "Addr.")]
        [MinLength(10)]
        [Required(ErrorMessage = "The length of the Address must be at least 10 characters")]
        public string Address { get; set; }
        [Display(Name = "Phone number")]
        [MinLength(10)]
        [Required(ErrorMessage = "The length of the Surname must be at least 10 characters")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [MinLength(10)]
        [Required(ErrorMessage = "The length of the Surname must be at least 10 characters")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
