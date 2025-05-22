using System.ComponentModel.DataAnnotations;

namespace clinica2.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Фамилия обязательна.")]
        [StringLength(50, ErrorMessage = "Фамилия не может превышать 50 символов.")]
        public string? first_name { get; set; }

        [Required(ErrorMessage = "Имя обязательно.")]
        [StringLength(50, ErrorMessage = "Имя не может превышать 50 символов.")]
        public string? last_name { get; set; }

        [Required(ErrorMessage = "Отчество обязательно.")]
        [StringLength(50, ErrorMessage = "Отчество не может превышать 50 символов.")]
        public string? middle_name { get; set; }

        [Required(ErrorMessage = "Дата рождения обязательна.")]
        [DataType(DataType.Date)]
        public DateTime? date_of_birth { get; set; }

        [Required(ErrorMessage = "Пол обязателен.")]
        [StringLength(20, ErrorMessage = "Пол не может превышать 20 символов.")]
        public string? gender { get; set; }

        [StringLength(50, ErrorMessage = "Номер полиса не может превышать 50 символов.")]
        public string? policy_number { get; set; }

        [Required]
        [Phone(ErrorMessage = "Неверный формат телефона")]
        public string? telephone { get; set; }

        [Required(ErrorMessage = "Логин обязателен.")]
        [StringLength(50, ErrorMessage = "Логин не может превышать 50 символов.")]
        public string? login { get; set; }

        [Required(ErrorMessage = "Пароль обязателен.")]
        [DataType(DataType.Password)]
        public string? password { get; set; }
        public int id_site { get; set; }
        public int id_role { get; set; }
    }
}
