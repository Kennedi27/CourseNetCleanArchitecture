using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repositories.Base;

namespace Movies.Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieContext movieContext) : base(movieContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetMovieByDirectorName(string directorName)
        {
            return await _movieContext.Movies
                                      .Where(p => p.DirectorName == directorName)
                                      .ToListAsync();
        }
    }
}
