using System.ComponentModel.DataAnnotations;

namespace GradingApp.Models
{
    public class Users
    {
        [Key]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
        
        [Required]
        public string role { get; set; }
    }
}
