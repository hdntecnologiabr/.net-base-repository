using System;
using System.ComponentModel.DataAnnotations;

namespace Hdn.Onboarding.Domain.Common
{
    public abstract class AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
