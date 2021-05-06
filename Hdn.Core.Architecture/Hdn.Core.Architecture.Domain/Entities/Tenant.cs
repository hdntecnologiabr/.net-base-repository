using Hdn.Core.Architecture.Domain.Common;
using System.Collections.Generic;

namespace Hdn.Core.Architecture.Domain.Entities
{
    public class Tenant : BaseEntity
    {        
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
