using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = "Status is required")]
        [Range(0, 4, ErrorMessage = "Error Status field")]
        public OrderStatusEnum OrderStatus { get; set; }
        public enum OrderStatusEnum
        {
            [Display(Name = "Selecting")]
            Selecting = 0,
            [Display(Name = "Aborted")]
            Aborted = 1,
            [Display(Name = "Checkout")]
            Checkout = 2,
            [Display(Name = "Delivering")]
            Delivering = 3,
            [Display(Name = "Received")]
            Received = 4,
            [Display(Name = "Refunded")]
            Refunded = 5,
        }
    }
}