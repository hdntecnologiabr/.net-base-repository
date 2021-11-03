using Hdn.Core.Architecture.Application.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hdn.Core.Architecture.Application.Services
{
    public interface IMovieService
    {
        Task<MovieResponseDto> GetAsync(Guid id);
        Task<IEnumerable<MovieResponseDto>> GetAllAsync();
        Task<MovieResponseDto> PostAsync(MoviePostRequestDto moviePostRequest);
        Task<MovieResponseDto> PutAsync(MoviePutRequestDto moviePutRequest);
        Task<bool> DeleteAsync(Guid id);
    }
}
