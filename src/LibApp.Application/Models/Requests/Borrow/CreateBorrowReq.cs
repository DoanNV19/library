using System;
using LibApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibApp.Application.Models.Requests
{
	public class CreateBorrowReq
	{
        public required Guid BookId { get; set; }
        public required Guid CustomerId { get; set; }
    }
}

