using LibApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Models.Requests
{
    public class AccountDisableReq
    {
        public List<Guid> Ids { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}
