﻿using Microsoft.AspNetCore.Mvc;

namespace LibApp.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected string GetUserId()
        {
            return this.User.Claims.First(i => i.Type == "id").Value;
        }
    }
}
