namespace MoviesLibraryWinForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:"

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }


    }
}
