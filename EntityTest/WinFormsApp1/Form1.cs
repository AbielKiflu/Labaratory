namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnMsg_Click(object sender, EventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync("https://www.google.com/");
            txtInput.Text = html;
            MessageBox.Show("Hi");
            btnMsg.Text = await LooperAsync();

        }


        private async Task<string> LooperAsync()
        {
            int counter = 0;
            await Task.Run(() =>
            {
                Task.Delay(2000);
                counter++;
            });

            return counter.ToString();
        }


    }
}