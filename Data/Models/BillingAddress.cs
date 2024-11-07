using System.ComponentModel.DataAnnotations;

namespace EsyaStore.Data.Models
{
    public class BillingAddress
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int ZIPCode { get; set; }
    }
}
