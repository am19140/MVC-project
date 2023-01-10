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
        public int idCourse { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Students")]
        public int registrationNumber { get; set; }
        public virtual Students Students { get; set; }

        public int grade { get; set; } 
    }
}
