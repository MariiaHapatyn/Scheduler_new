using System.ComponentModel.DataAnnotations;

namespace Scheduler.DTO.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
