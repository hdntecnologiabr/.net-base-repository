using Hdn.Core.Architecture.Application.Common.Mappings;
using Hdn.Core.Architecture.Domain.Entities;

namespace Hdn.Core.Architecture.Application.Dtos.Movie
{
    public class MoviePutRequestDto : IMapFrom<MovieEntity>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Popularity { get; set; }
        public StatusTypeDto Status { get; set; }
    }
}
