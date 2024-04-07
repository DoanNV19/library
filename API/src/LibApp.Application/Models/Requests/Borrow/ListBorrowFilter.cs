using System;
using LibApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibApp.Application.Models.Requests
{
	public class ListBorrowFilter:PagerReq
    {
       public Guid? BookId { get; set; }
       public Guid? CustomerId { get; set; }
    }
}

