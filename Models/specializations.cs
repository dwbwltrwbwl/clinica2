using System.ComponentModel.DataAnnotations;

namespace clinica2.Models
{
    public class specializations
    {
        [Key]
        public int id_specialization { get; set; }
        [Required]
        [StringLength(50)]
        public string? specialization_name { get; set; }

        public ICollection<doctors>? doctors { get; set; }
    }
}
