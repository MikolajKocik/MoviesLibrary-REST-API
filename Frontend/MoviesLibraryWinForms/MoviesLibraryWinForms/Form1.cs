using MoviesLibraryWinForms.Models;
using System.Net.Http.Json;

namespace MoviesLibraryWinForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:7295/api/movies"; // connect with API 

        /// <summary>
        /// Initializes HttpClient and setup for edit/delete buttons 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            SetupDataGridViewButtons();
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Allows to load data from LoadMoviesAsync method
        /// </summary>
        
        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadMoviesAsync();
        }

        /// <summary>
        /// Load all data from API - get movies endpoint
        /// </summary>
     
        private async Task LoadMoviesAsync()
        {
            try
            {
                // get data from API 
                var movies = await _httpClient.GetFromJsonAsync<List<Movie>>(ApiUrl);
                dataGridViewMovies.DataSource = movies;

                if (dataGridViewMovies.Columns["Id"] != null)
                {
                    dataGridViewMovies.Columns["Id"].Visible = false;
                }

                // set buttons edit and delete next to list elements

                if (dataGridViewMovies.Columns["EditButton"] != null)
                {
                    dataGridViewMovies.Columns["EditButton"].DisplayIndex = dataGridViewMovies.Columns.Count - 1;
                }

                if (dataGridViewMovies.Columns["DeleteButton"] != null)
                {
                    dataGridViewMovies.Columns["DeleteButton"].DisplayIndex = dataGridViewMovies.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data" + ex.Message);
            }
        }

        /// <summary>
        /// Add new movie and send request to API - post endpoint
        /// </summary>
     
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var modalForm = new FormMovie())
            {
                if (modalForm.ShowDialog() == DialogResult.OK)
                {
                    var newMovie = modalForm.Movie;

                    // send request to API to add movie
                    var response = await _httpClient.PostAsJsonAsync(ApiUrl, newMovie);
                    if (response.IsSuccessStatusCode)
                    {
                        await LoadMoviesAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error while adding data");
                    }
                }
            }
        }

        /// <summary>
        /// Set DataGridViewButtons and adding to column 
        /// </summary>

        private void SetupDataGridViewButtons()
        {
            if (!dataGridViewMovies.Columns.Contains("EditButton"))
            {
                DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "EditButton",
                    HeaderText = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };

                dataGridViewMovies.Columns.Add(editButtonColumn);
            }

            if (!dataGridViewMovies.Columns.Contains("DeleteButton"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "DeleteButton",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                
                dataGridViewMovies.Columns.Add(deleteButtonColumn);
            }
        }

        /// <summary>
        /// The configuration of main window, where user can edit or delete data
        /// </summary>

        private async void dataGridViewMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridViewMovies.Columns[e.ColumnIndex].Name;
            Movie movie = (Movie)dataGridViewMovies.Rows[e.RowIndex].DataBoundItem;

            if (movie == null) return;

            if (columnName == "EditButton")
            {
                using (FormMovie modalForm = new FormMovie(movie))
                {
                    if (modalForm.ShowDialog() == DialogResult.OK)
                    {
                        // after closing the form, data is up to date
                        var updateMovie = modalForm.Movie;

                        // send changes to API database 
                        var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{movie.Id}", movie);

                        if (response.IsSuccessStatusCode)
                        {
                            await LoadMoviesAsync();
                        }
                        else
                        {
                            MessageBox.Show("Error while editing data");
                        }
                    }
                }
            }
            else if (columnName == "DeleteButton")
            {
                var confirm = MessageBox.Show("Are you sure that you want to delete the data?", "Confirmation", MessageBoxButtons.YesNo);

                // note about MessageBox.YesNo: name of button depends on operating system language

                if (confirm == DialogResult.Yes)
                {
                    // delete data and send request to API
                    var response = await _httpClient.DeleteAsync($"{ApiUrl}/{movie.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        await LoadMoviesAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error while removing data");
                    }
                }
            }
        }
    }
}
