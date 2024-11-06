using System.ComponentModel.DataAnnotations;

namespace EsyaStore.Data.Models
{
    public class TuserRegistration
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Contect { get; set; }
        [Required]
        public int IsActive { get; set; } = 1;

    }
}
