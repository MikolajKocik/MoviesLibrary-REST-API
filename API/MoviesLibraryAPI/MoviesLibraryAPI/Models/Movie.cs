namespace MoviesLibraryAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public int Year { get; set; }
    }
}
