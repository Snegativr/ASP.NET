using System.ComponentModel.DataAnnotations;

namespace AspNetMVC.Models
{
    public class Product
    {
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Amount of selected product must be >= 0")]
        public int Quantity { get; set; }
    }

}