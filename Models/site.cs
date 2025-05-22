using System.ComponentModel.DataAnnotations;

namespace clinica2.Models
{
    public class site
    {
        [Key]
        public int id_site { get; set; }
        [Required]
        [StringLength(50)]
        public string? site_number { get; set; }

        public ICollection<patients>? patients { get; set; }
    }
}
