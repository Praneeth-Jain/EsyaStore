using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace EsyaStore.Pages.Shared.SignupModel
{
    public class SignupModelClass
    {
        [Required]
        [EmailAddress(ErrorMessage = "Enter valid Email Address")]

        public string Username { get; set; }

        [Required(ErrorMessage = "Password please :(")]
        public string Password { get; set; }

    }
}

