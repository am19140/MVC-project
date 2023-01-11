using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingApp.Models
{
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int registressionNumber { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string department { get; set; }

        [ForeignKey("Users")]
        [Required]
        public string username { get; set; }
        public virtual Users Users { get; set; }
    }
}
