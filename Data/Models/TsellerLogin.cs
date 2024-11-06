using System.ComponentModel.DataAnnotations;

namespace EsyaStore.Data.Models
{
    public class TsellerLogin
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
