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



        public PaymentTypeEnum PaymentTypeId { get; set; }
        public double TotalPrice { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhone { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }


        public OrderStatusEnum OrderStatus { get; set; }
        public enum OrderStatusEnum
        {
            [Display(Name = "Pending")]
            Pending = 5,
            [Display(Name = "Confirm")]
            Confirm = 4,
            [Display(Name = "Shipping")]
            Shipping = 3,
            [Display(Name = "Paid")]
            Paid = 2,
            [Display(Name = "Cancel")]
            Cancel = 0,
            [Display(Name = "Done")]
            Done = 1,
            [Display(Name = "Deleted")]
            Deleted = -1,
        }
        public enum PaymentTypeEnum
        {
            [Display(Name = "Cod")]
            Cod = 1,
            [Display(Name = "InternetBanking")]
            InternetBanking = 2,
            [Display(Name = "DirectTransfer")]
            DirectTransfer = 3
        }
        public Order()
        {
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = DateTime.Now.Ticks;
            OrderStatus = OrderStatusEnum.Pending;
        }
    }
}