using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}