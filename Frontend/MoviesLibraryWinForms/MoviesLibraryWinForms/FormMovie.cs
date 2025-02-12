using MoviesLibraryWinForms.Models;

namespace MoviesLibraryWinForms
{
    public partial class FormMovie : Form
    {
        public Movie Movie { get; private set; }

        /// <summary>
        /// Add movie action constructor
        /// </summary>// add action constructor
        public FormMovie()
        {
            InitializeComponent();
            Movie = new Movie();
        }

        /// <summary>
        /// Edit movie action constructor
        /// </summary>
        
        public FormMovie(Movie movie) : this()
        {
            Movie = movie;
            txtTitle.Text = movie.Title;
            txtYear.Text = movie.Year.ToString();

        }

        /// <summary>
        /// Represents the button ation that allows user to add/edit movie
        /// </summary>
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Validations for Title 
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Title is required.");
                return;
            }

            if (txtTitle.Text.Length > 200)
            {
                MessageBox.Show("The title can be a maximum of 200 characters.");
                return;
            }

            // Validations for Year
            if (!int.TryParse(txtYear.Text, out int year) || year < 1900 || year > 2200)
            {
                MessageBox.Show("The year must be between 1900 and 2200.");
                return;
            }

            Movie.Title = txtTitle.Text;
            Movie.Year = year;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Represents the button action where user can close the form
        /// </summary>
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
