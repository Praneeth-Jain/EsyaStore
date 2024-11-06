using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace EsyaStore.Data.Models
{
    public class TsellerRegistration
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Contact {  get; set; }
        [Required]
        public string Location { get; set; }
    }
}
