namespace MoviesLibraryAPI.Entities
{
    public class Movie
    {
        private int id;
        private string title = default!;
        private int year;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
    }
}
