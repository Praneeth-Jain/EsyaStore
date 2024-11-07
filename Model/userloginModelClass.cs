using System.ComponentModel.DataAnnotations;

namespace EsyaStore.Model
{
    public class userloginModelClass
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
