using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Models.Requests
{
    public class AccountChangePass
    {
        [Required]
        [MaxLength(50)]
        public string NewPass { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string OldPass { get; set; }
    }
}
