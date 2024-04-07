using System;
using LibApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using LibApp.Application.Models.Responses.Customer;

namespace LibApp.Application.Models.Responses
{
	public class BorrowPriceDtoRes
    {
        public int Price { get; set; }
    }
}

