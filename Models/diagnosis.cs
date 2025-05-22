using System.ComponentModel.DataAnnotations;

namespace clinica2.Models
{
    public class diagnosis
    {
        [Key]
        public int id_diagnosis { get; set; }
        [Required]
        [StringLength(50)]
        public string? diagnosis_name { get; set; }

        public ICollection<receptions>? receptions { get; set; }
    }
}
