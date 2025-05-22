using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinica2.Models
{
    public class doctors
    {
        [Key]
        public int id_doctor { get; set; }
        [Required]
        [StringLength(50)]
        public string? first_name { get; set; }
        [Required]
        [StringLength(50)]
        public string? last_name { get; set; }
        [Required]
        [StringLength(50)]
        public string? middle_name { get; set; }
        [Required]
        [StringLength(20)]
        public string? telephone { get; set; }
        [Required]
        [StringLength(50)]
        public string? login { get; set; }
        [Required]
        [StringLength(50)]
        public string? password { get; set; }
        [StringLength(50)]
        public string? image { get; set; }

        public int id_specialization { get; set; }
        [ForeignKey("id_specialization")]
        public specializations? specializations { get; set; }

        public int id_role { get; set; }
        [ForeignKey("id_role")]
        public roles? roles { get; set; }

        public ICollection<receptions>? receptions { get; set; }
    }
}
