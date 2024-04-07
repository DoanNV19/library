using LibApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibApp.Application.Models.Responses
{
    public class AuthorDtoRes
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public virtual Country? Country { get; set; }
    }
}
