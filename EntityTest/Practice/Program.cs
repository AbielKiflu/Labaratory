using MiNET.UI;
using System;



namespace WindowsFormsApp
{
    public class MyForm : Form
    {
        public MyForm()
        {
            // Set the properties of the form
            this.Text = "My Windows Form";
            this.Width = 400;
            this.Height = 300;

            // Create and configure controls
            var button = new Button();
            button.Text = "Click Me";
            button.Click += Button_Click;

            // Add controls to the form
            this.Controls.Add(button);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clicked!");
        }

        // Entry point of the application
        public static void Main()
        {
            Application.Run(new MyForm());
        }
    }
}