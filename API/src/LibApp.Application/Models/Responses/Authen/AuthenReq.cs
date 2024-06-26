﻿using LibApp.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Models.Responses
{
    public class AuthenRes
    {
        public required string AccessToken { get; set; }
        public UserDTO? User { get; set; }
    }
}
