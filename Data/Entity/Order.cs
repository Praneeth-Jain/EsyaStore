using System.ComponentModel.DataAnnotations;

namespace EsyaStore.Data.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OrderNo { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        public DateTime OrderDate { get; set; }= DateTime.Now;

        public int OrderStatus { get; set; } = 1;

    }
}
