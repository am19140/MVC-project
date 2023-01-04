using System.ComponentModel.DataAnnotations;

namespace GradingApp.Models
{
    public class LoginModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public bool IsLoginConfirmed { get; set; } = true;

    }
}
