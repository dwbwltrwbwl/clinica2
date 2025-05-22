using System.ComponentModel.DataAnnotations;

namespace clinica2.Models
{
    public class status
    {
        [Key]
        public int id_status { get; set; }
        [Required]
        [StringLength(50)]
        public string? status_name { get; set; }

        public ICollection<receptions>? receptions { get; set; }
    }
}
