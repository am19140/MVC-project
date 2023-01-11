using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingApp.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
        
        [Required]
        public string role { get; set; }
    }
}
