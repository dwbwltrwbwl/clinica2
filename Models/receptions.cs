using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clinica2.Models
{
    public class receptions
    {
        [Key]
        public int id_reception { get; set; }
        public DateTime? date_reception { get; set; }
        public TimeSpan? time_reception { get; set; }

        public int id_patient { get; set; }
        [ForeignKey("id_patient")]
        public patients? patients { get; set; }

        public int id_doctor { get; set; }
        [ForeignKey("id_doctor")]
        public doctors? doctors { get; set; }

        public int id_status { get; set; }
        [ForeignKey("id_status")]
        public status? status { get; set; }

        [StringLength(100)]
        public string? symptoms { get; set; }

        public int id_diagnosis { get; set; }
        [ForeignKey("id_diagnosis")]
        public diagnosis? diagnosis { get; set; }

        [StringLength(100)]
        public string? treatment { get; set; }
    }
}
