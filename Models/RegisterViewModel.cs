using System.ComponentModel.DataAnnotations;

namespace clinica2.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Фамилия обязательна.")]
        [StringLength(50, ErrorMessage = "Фамилия не может превышать 50 символов.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Имя обязательно.")]
        [StringLength(50, ErrorMessage = "Имя не может превышать 50 символов.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Отчество обязательно.")]
        [StringLength(50, ErrorMessage = "Отчество не может превышать 50 символов.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Электронная почта обязательна.")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Логин обязателен.")]
        [StringLength(50, ErrorMessage = "Логин не может превышать 50 символов.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль обязателен.")]
        [StringLength(50, ErrorMessage = "Пароль не может превышать 50 символов.")]
        public string Password { get; set; }
        public int IdRole { get; set; }
    }
}
