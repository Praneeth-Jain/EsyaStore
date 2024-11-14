using System.ComponentModel.DataAnnotations;

namespace EsyaStore.Model
{
    public class ProductModel
    {

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        public string Manufacturer { get; set; }

        public IFormFile ProductImg { get; set; }

        [Range(0,100)]
        public int Discount { get; set; }


    }
}
