﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Models.Requests
{
    public class CreateAuthorReq
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
        public Guid? CountryId { get; set; }

    }
}
