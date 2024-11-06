using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;



namespace EsyaStore.Pages.Shared.RegisterModelClass
{
    public class RegisterModelClass
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(10)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]

        public string Location {  get; set; }

    }
}
