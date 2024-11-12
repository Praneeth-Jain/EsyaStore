namespace EsyaStore.Model
{
    public class Sellerorderviewmodel
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatus { get; set; }

        public int Quantity { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; } 

        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public string Manufacturer { get; set; }
        public string ProdImgUrl { get; set; }

        public string UserEmail {  get; set; }
        
        public string UserContact { get; set; }
    }
}
