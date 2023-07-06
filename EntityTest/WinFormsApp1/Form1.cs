using System.CodeDom;
using System.Windows.Forms;

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
            txtInput.Text = "";
            txtInput.Text = html;
            
            //btnMsg.Text = await LooperAsync();

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

        private async void btnLoop_Click(object sender, EventArgs e)
        {
            int counter = int.MaxValue;
            btnLoop.Enabled = false;
            try
            {
                await Task.Run(() => {
                    for (int i = 0; i < counter; i++)
                    {
                        // Frozen  btnLoop.Text = i.ToString()
                        try
                        {
                            Invoke((Action)(() => btnLoop.Text = i.ToString()));
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                });
            }
            finally
            {
                btnLoop.Enabled = true;
            }


        }
    }
}