using System.ComponentModel.DataAnnotations;
using LibApp.Domain.Core.Models;
using LibApp.Domain.Enums;

namespace LibApp.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
    }
}
