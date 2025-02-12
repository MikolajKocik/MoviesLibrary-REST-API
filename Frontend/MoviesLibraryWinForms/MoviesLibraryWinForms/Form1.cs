using MoviesLibraryWinForms.Models;
using System.Net.Http.Json;

namespace MoviesLibraryWinForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:7295";

        public Form1()
        {
            InitializeComponent();
            SetupDataGridViewButtons();
            _httpClient = new HttpClient();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadMoviesAsync();
        }

        private async Task LoadMoviesAsync()
        {
            try
            {
                var movies = await _httpClient.GetFromJsonAsync<List<Movie>>(ApiUrl);
                dataGridViewMovies.DataSource = movies;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading data" + ex.Message);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var modalForm = new FormMovie())
            {
                if (modalForm.ShowDialog() == DialogResult.OK)
                {
                    var newMovie = modalForm.Movie;
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

        private async void dataGridViewMovies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridViewMovies.Columns[e.ColumnIndex].Name;
            Movie movie = (Movie)dataGridViewMovies.Rows[e.RowIndex].DataBoundItem;

            if (movie == null) return;

            if (columnName == "EditButton")
            {
                using (FormMovie modalForm = new FormMovie())
                {
                    if (modalForm.ShowDialog() == DialogResult.OK)
                    {
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

                if (confirm == DialogResult.Yes)
                {
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
