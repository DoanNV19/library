﻿namespace LibApp.Application.Models.Requests
{
    public class PagerReq
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public string? KeySearch { get; set; }
    }
}
