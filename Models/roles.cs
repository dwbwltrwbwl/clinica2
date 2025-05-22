using System.ComponentModel.DataAnnotations;

namespace clinica2.Models
{
    public class roles
    {
        [Key]
        public int id_role { get; set; }
        [Required]
        [StringLength(50)]
        public string? role_name { get; set; }

        public ICollection<doctors>? doctors { get; set; }
        public ICollection<patients>? patients { get; set; }
    }
}
