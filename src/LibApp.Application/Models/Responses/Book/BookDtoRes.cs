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
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [MaxLength(255)]
        public Guid AuthoId { get; set; }

        public int Page { get; set; }
        public int Price { get; set; }
        public AuthorDtoRes? Author { get; set; }
    }
}
