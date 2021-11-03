using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hdn.Core.Architecture.Application.Dtos.Movie;
using Hdn.Core.Architecture.Domain.Entities;
using Hdn.Core.Architecture.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> DeleteAsync(Guid id) =>
            await movieRepository.DeleteAsync(id);


        public async Task<IEnumerable<MovieResponseDto>> GetAllAsync()
        {
            var listFilm = await movieRepository.SelectAsync();

            return listFilm.AsQueryable()
                           .ProjectTo<MovieResponseDto>(mapper.ConfigurationProvider);
        }

        public async Task<MovieResponseDto> GetAsync(Guid id)
        {
            var movieEntity = await movieRepository.SelectAsync(id);
            return mapper.Map<MovieResponseDto>(movieEntity);
        }

        public async Task<MovieResponseDto> PostAsync(MoviePostRequestDto moviePostRequest)
        {
            var movieEntity = mapper.Map<MovieEntity>(moviePostRequest);
            var result = await movieRepository.InsertAsync(movieEntity);
            return mapper.Map<MovieResponseDto>(result);
        }

        public async Task<MovieResponseDto> PutAsync(MoviePutRequestDto moviePutRequest)
        {
            var movieEntity = mapper.Map<MovieEntity>(moviePutRequest);
            var result = await movieRepository.UpdateAsync(movieEntity);
            return mapper.Map<MovieResponseDto>(result);
        }
    }
}
