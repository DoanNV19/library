using LibApp.Application.Models.Responses.Author;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Models.Responses.Book
{
    public class BookDtoRes
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid AuthorId { get; set; }
        public int Page { get; set; }
        public int Price { get; set; }
        public AuthorDtoRes? Author { get; set; }
    }
}
