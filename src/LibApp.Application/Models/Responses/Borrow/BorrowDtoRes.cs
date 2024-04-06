using System;
using LibApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using LibApp.Application.Models.Responses.Customer;

namespace LibApp.Application.Models.Responses
{
	public class BorrowDtoRes
	{
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset? ReturnDate { get; set; }
        public int? Price { get; set; }
        public BookDtoRes? Book { get; set; }
        public CustomerDtoRes? Customer { get; set; }
    }
}

