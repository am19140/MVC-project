using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingApp.Models
{
    public class Course
    {
        [Key]
        public int idCourse { get; set; }

        [Required]
        public string courseTitle { get; set; }

        [Required]
        public int courseSemester { get; set; }

        [ForeignKey("Professors")]
        [Required]
        public int afm { get; set; }
        public virtual Professors Professors { get; set; }
    }
}
