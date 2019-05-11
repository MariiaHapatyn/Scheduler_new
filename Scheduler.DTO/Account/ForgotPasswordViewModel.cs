using System.ComponentModel.DataAnnotations;

namespace Scheduler.DTO.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
