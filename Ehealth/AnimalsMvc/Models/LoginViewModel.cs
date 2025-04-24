using System.ComponentModel.DataAnnotations;

namespace AnimalsMvc.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Le rôle est requis")]
        public string Role { get; set; }

        public bool RememberMe { get; set; }
    }
}