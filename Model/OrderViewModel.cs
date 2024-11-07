namespace EsyaStore.Model
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public string OrderNo { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public DateTime OrderDate { get; set; }

        public int OrderStatus { get; set; } 
    }
}
