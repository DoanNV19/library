using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Models.Responses
{
    public class AccountDtoRes
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
