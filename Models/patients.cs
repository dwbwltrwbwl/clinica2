using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinica2.Models
{
    public class patients
    {
        [Key]
        public int id_patient { get; set; }
        [Required]
        [StringLength(50)]
        public string? first_name { get; set; }
        [Required]
        [StringLength(50)]
        public string? last_name { get; set; }
        [Required]
        [StringLength(50)]
        public string? middle_name { get; set; }
        public DateTime? date_of_birth { get; set; }
        [Required]
        [StringLength(20)]
        public string? gender { get; set; }
        [StringLength(50)]
        public string? policy_number { get; set; }
        [Required]
        [StringLength(20)]
        public string? telephone { get; set; }
        [Required]
        [StringLength(50)]
        public string? login { get; set; }
        [Required]
        [StringLength(50)]
        public string? password { get; set; }

        public int id_site { get; set; }
        [ForeignKey("id_site")]
        public site? site { get; set; }

        public int id_role { get; set; }
        [ForeignKey("id_role")]
        public roles? roles { get; set; }

        public ICollection<receptions>? receptions { get; set; }
    }
}
