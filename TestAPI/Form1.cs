namespace TestAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hell World");
            GetApiDataAsync(textBox1.Text);
        }
        private static readonly HttpClient client = new HttpClient();



        private static async Task GetApiDataAsync(String codigo)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost/apis/productos.php?codigo=" + codigo);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
