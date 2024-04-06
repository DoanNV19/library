using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibApp.Domain.Core.Models;
using LibApp.Domain.Enums;

namespace LibApp.Domain.Entities
{
    public class Author : BaseEntity
    {
        public required string Name { get; set; }
        public string? Country { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
