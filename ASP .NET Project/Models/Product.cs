using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "The Description is required")]
        public string Description { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "The Price is required")]
        public double Price { get; set; }

        [DisplayName("InStoke")]
        [Required(ErrorMessage = "The InStoke is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The InStoke must be greater than or equal 0")]
        public int InStoke { get; set; }

    }
}