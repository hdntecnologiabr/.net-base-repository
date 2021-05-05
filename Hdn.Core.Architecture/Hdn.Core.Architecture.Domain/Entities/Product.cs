using Hdn.Core.Architecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hdn.Core.Architecture.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
