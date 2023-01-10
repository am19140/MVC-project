using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingApp.Models
{
    [PrimaryKey(nameof(idCourse), nameof(registrationNumber))]
    public class CourseHasStudents
    {
        [ForeignKey("Course")]
        [Required]
        public int idCourse { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Students")]
        [Required]
        public int registrationNumber { get; set; }
        public virtual Students Students { get; set; }

        [Required]
        public int grade { get; set; } 
    }
}
