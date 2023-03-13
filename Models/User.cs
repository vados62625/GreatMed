using System.ComponentModel.DataAnnotations;

namespace MotoHelp.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Адрес эл. почты")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
