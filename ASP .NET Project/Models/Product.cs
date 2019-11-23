using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

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
        [Range(0, double.MaxValue, ErrorMessage = "The Price cannot be less than 0")]
        public double Price { get; set; }

        [DisplayName("InStoke")]
        [Required(ErrorMessage = "The InStoke is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The InStoke must be greater than or equal 0")]
        public int InStoke { get; set; }

        [JsonIgnore]
        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [JsonIgnore]
        public virtual Brand Brand { get; set; }

        [JsonIgnore]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [DisplayName("Picture")]
        [Required(ErrorMessage = "The Picture is required")]
        public string Picture { get; set; }
    }
}