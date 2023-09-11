using Movies.Core.Entities.Base;

namespace Movies.Core.Entities
{
    public class Movie : Entity
    {
        public string MovieName { get; set; } = string.Empty;
        public string DirectorName { get; set; } = string.Empty;
        public string ReleaseYear { get; set; } = string.Empty;

    }
}
