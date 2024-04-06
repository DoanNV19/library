using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibApp.Domain.Core.Models;
using LibApp.Domain.Enums;

namespace LibApp.Domain.Entities
{
    public class Book : BaseEntity
    {

        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Page { get; set; }
        public int Price { get; set; }
        public BookStatus Status { get; set; }
        [ForeignKey("User")]
        public required Guid AuthorId { get; set; }
        public virtual Author? Author { get; set; }
    }
}
