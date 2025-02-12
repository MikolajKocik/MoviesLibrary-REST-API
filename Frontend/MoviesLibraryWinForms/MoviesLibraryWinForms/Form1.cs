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
                dataGridView1.DataSource = movies;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during load data" + ex.Message);
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
                        MessageBox.Show("Error while adding movie");
                    }
                }
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            //
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
