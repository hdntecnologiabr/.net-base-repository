using Hdn.Onboarding.Domain.Common;
using Hdn.Onboarding.Domain.Enumerator;

namespace Hdn.Core.Architecture.Domain.Entities
{
    public class MovieEntity : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Popularity { get; set; }
        public StatusType Status { get; set; }
    }
}
