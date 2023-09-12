using Microsoft.Extensions.Logging;
using Movies.Core.Entities;

namespace Movies.Infrastructure.Data
{
    public class MovieContextSeed
    {
        public static async Task SeedAsync(MovieContext movieContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                await movieContext.Database.EnsureCreatedAsync();

                if (!movieContext.Movies.Any())
                {
                    movieContext.Movies.AddRange(GetMovies());
                    await movieContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if(retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<MovieContextSeed>();
                    log.LogError($"Exception occured while connectiong: {ex.Message}");
                    await SeedAsync(movieContext, loggerFactory, retryForAvailability);
                }
            }
        }

        private static IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>()
            {
                new Movie { MovieName = "KKN di Desa Penari", DirectorName = "Awi Suryadi", ReleaseYear = "2022" },
                new Movie { MovieName = "Warkop DKI Reborn: Jangkrik Boss! Part 1", DirectorName = "Anggy Umbara", ReleaseYear = "2016" },
                new Movie { MovieName = "Pengabdi Setan 2: Communion", DirectorName = "Joko Anwar", ReleaseYear = "2022" },
                new Movie { MovieName = "Dilan 1990", DirectorName = "Fajar Bustomi Pidi Baiq", ReleaseYear = "2018" },
                new Movie { MovieName = "Miracle in Cell No. 7", DirectorName = "Hanung Bramantyo", ReleaseYear = "2022" },
                new Movie { MovieName = "Dilan 1991", DirectorName = "Fajar Bustomi Pidi Baiq", ReleaseYear = "2019" },
                new Movie { MovieName = "Sewu Dino", DirectorName = "Kimo Stamboel", ReleaseYear = "2023" },
                new Movie { MovieName = "Laskar Pelangi", DirectorName = "Riri Riza", ReleaseYear = "2008" },
                new Movie { MovieName = "Habibie & Ainun", DirectorName = "Faozan Rizal", ReleaseYear = "2012" },
                new Movie { MovieName = "Pengabdi Setan", DirectorName = "Joko Anwar", ReleaseYear = "2017" }
            };
        }
    }
}
