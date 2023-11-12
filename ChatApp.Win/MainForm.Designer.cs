namespace ChatApp.Win
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginScreen = new LoginControl();
            SuspendLayout();
            // 
            // LoginScreen
            // 
            LoginScreen.BackColor = Color.FromArgb(44, 44, 44);
            LoginScreen.Dock = DockStyle.Fill;
            LoginScreen.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point);
            LoginScreen.Location = new Point(0, 0);
            LoginScreen.Name = "LoginScreen";
            LoginScreen.Size = new Size(987, 505);
            LoginScreen.TabIndex = 0;
            LoginScreen.OnLoginSuccess += LoginScreen_OnLoginSuccess;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(44, 44, 44);
            ClientSize = new Size(987, 505);
            Controls.Add(LoginScreen);
            Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Chat App";
            Paint += MainForm_Paint;
            ResumeLayout(false);
        }

        #endregion

        private LoginControl LoginScreen;
    }
}