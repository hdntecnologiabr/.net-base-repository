using Hdn.Core.Architecture.Domain.Common;

namespace Hdn.Core.Architecture.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int TenantId { get; set; }
        //public virtual Tenant Tenant { get; set; }
    }
}
