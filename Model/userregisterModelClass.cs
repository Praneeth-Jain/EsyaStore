using System.ComponentModel.DataAnnotations;

namespace EsyaStore.Model
{
    public class userregisterModelClass
    {
        [Required]
        public string Name;

        [Required]
        public string Email;

        [Required]
        public string Password;

        [Required]
        public string Confirmpassword;

        [Required]
        public string Contact;
    }
}
