namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtInput = new TextBox();
            btnMsg = new Button();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(189, 44);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(489, 208);
            txtInput.TabIndex = 0;
            // 
            // btnMsg
            // 
            btnMsg.Location = new Point(115, 283);
            btnMsg.Name = "btnMsg";
            btnMsg.Size = new Size(498, 23);
            btnMsg.TabIndex = 1;
            btnMsg.Text = "Show";
            btnMsg.UseVisualStyleBackColor = true;
            btnMsg.Click += btnMsg_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMsg);
            Controls.Add(txtInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private Button btnMsg;
    }
}