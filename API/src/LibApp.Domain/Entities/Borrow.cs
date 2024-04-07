using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibApp.Domain.Core.Models;
using LibApp.Domain.Enums;

namespace LibApp.Domain.Entities
{
    public class Borrow : BaseEntity
    {
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset? ReturnDate { get; set; }
        public int? Price { get; set; }
        [ForeignKey("Book")]
        public required Guid BookId { get; set; }
        public virtual Book? Book { get; set; }
        [ForeignKey("Customer")]
        public required Guid CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
