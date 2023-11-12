using ChatApp.Models.Dtos.User;
using ChatApp.Win.ApiConsuming;
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
    public partial class ChatControl : UserControl
    {
        UserReadDto CurrentUser;
        public ChatControl(UserReadDto user)
        {
            this.CurrentUser = user;
            InitializeComponent();
        }

        private async void ChatControl_Load(object sender, EventArgs e)
        {
            IEnumerable<UserReadProfileDto>? users = await UserApi.UserContacts(CurrentUser);

            if (users is null)
            {
                MessageBox.Show("Contacts list is null");
                return;
            }

            foreach (var user in users)
            {
                pnl_ContactList.Controls.Add(GetContactButton(user));
            }
        }

        private Button GetContactButton(UserReadProfileDto user)
        {
            Button btn_Contact = new Button();
            btn_Contact.BackColor = Color.FromArgb(30, 30, 30);
            btn_Contact.Dock = DockStyle.Top;
            btn_Contact.FlatAppearance.BorderSize = 0;
            btn_Contact.FlatStyle = FlatStyle.Flat;
            btn_Contact.Font = new Font("Arial", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Contact.ForeColor = Color.FromArgb(255, 209, 0);
            btn_Contact.Location = new Point(0, 60);
            btn_Contact.Name = "btn_Chat_" + user.UserName;
            btn_Contact.Padding = new Padding(30, 0, 0, 0);
            btn_Contact.Size = new Size(250, 50);
            btn_Contact.TabIndex = 1;
            btn_Contact.Text = user.UserName;
            btn_Contact.TextAlign = ContentAlignment.MiddleLeft;
            btn_Contact.UseVisualStyleBackColor = false;
            btn_Contact.Tag = user;
            btn_Contact.Click += btn_Contact_Click;

            return btn_Contact;
        }



        private async void btn_Contact_Click(object sender, EventArgs e)
        {
            ChooseButton(sender);

            Button ContactButton = (Button)sender;
            UserReadProfileDto user = (UserReadProfileDto)ContactButton.Tag;


        }

        private void ChooseButton(object sender)
        {
            Button button = (Button)sender;

            foreach(Control c in pnl_ContactList.Controls)
            {
                if(c is Button)
                {
                    c.BackColor = Color.FromArgb(30,30,30);
                }
            }

            button.BackColor = Color.FromArgb(44, 44, 44);

        }
    }
}
