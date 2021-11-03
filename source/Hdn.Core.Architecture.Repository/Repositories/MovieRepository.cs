using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using Hdn.Core.Architecture.Repository.Context;

namespace Hdn.Core.Architecture.Repository.Repositories
{
    public class MovieRepository : BaseRepository<MovieEntity>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
