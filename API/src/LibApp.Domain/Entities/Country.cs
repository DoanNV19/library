using System.ComponentModel.DataAnnotations;
using LibApp.Domain.Core.Models;
using LibApp.Domain.Enums;

namespace LibApp.Domain.Entities
{
    public class Country : BaseEntity
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
