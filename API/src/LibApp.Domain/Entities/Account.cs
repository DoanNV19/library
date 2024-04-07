using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibApp.Domain.Core.Models;
using LibApp.Domain.Enums;

namespace LibApp.Domain.Entities
{
    public class Account : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {

        public required string UserName { get; set; }
        public required string Password { get; set; }
        public AccountStatus Status { get; set; } = AccountStatus.Active;
        [ForeignKey("User")]
        public required Guid UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
