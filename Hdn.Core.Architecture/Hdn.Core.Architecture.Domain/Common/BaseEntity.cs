using System;

namespace Hdn.Core.Architecture.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public Guid RowId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }

    }
}
