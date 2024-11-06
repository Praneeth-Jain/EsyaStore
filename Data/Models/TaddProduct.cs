namespace EsyaStore.Data.Models
{
    public class TaddProduct
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductQuantity {  get; set; }
        
        public string ProductCategory { get; set; }

        public string Manufacturer { get; set; }

        public IFormFile ProductImage { get; set; }


    }
}
