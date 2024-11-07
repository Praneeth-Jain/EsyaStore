using System.ComponentModel.DataAnnotations;

namespace EsyaStore.Model
{
    public class userregisterModelClass
    {
        [Required]
        
        public string Name { get; set; }

        [Required]
        public string Email {  get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Confirmpassword { get; set; }

        [Required]
        public string Contact {  get; set; }
    }
}
