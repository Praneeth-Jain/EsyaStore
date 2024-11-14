namespace EsyaStore.Model
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public string OrderNo { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }

        public decimal OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public int OrderStatus { get; set; } 

        public int Quanity { get; set; }


        public string Address { get; set; }
    }
}
