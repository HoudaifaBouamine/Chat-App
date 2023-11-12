using ChatApp.Models.Dtos.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp.Win
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void LoginScreen_OnLoginSuccess(UserReadDto? userName)
        {
            if (userName == null)
            {
                MessageBox.Show("Login Failed");
            }

            this.LoginScreen.Visible = false;
            ChatControl chatControl = new ChatControl(userName);
            chatControl.Dock = DockStyle.Fill;
            this.Controls.Add(chatControl);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
