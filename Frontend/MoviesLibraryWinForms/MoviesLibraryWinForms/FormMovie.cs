using MoviesLibraryWinForms.Models;

namespace MoviesLibraryWinForms
{
    public partial class FormMovie : Form
    {
        public Movie Movie { get; private set; }
        public FormMovie()
        {
            InitializeComponent();
            Movie = new Movie();
        }

        public FormMovie(Movie movie) : this()
        {
            Movie = movie;
            txtTitle.Text = movie.Title;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
