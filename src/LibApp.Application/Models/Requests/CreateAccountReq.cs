using System.ComponentModel.DataAnnotations;
using LibApp.Domain.Enums;

namespace LibApp.Application.Models.Requests
{
    public class CreateAccountReq
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
