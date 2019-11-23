using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class CartItem
    {

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}