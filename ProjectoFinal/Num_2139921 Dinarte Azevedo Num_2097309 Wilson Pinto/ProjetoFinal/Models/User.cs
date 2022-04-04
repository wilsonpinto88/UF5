using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string? PicturePath { get; set; }

        [Required]
        public string Password { get; set; }
        public string Country { get; set; }
        //public string ?Gender { get; set; }
    }
}
