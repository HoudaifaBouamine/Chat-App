using ChatApp.Models.Dtos.User;
using ChatApp.Win.ApiConsuming;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ChatApp.Win
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void LoginControl_Paint(object sender, PaintEventArgs e)
        {
            pnl_Left.Width = this.Width / 3;
        }

        public event Action<UserReadDto>? OnLoginSuccess = null;
        protected virtual void LoginSuccess(UserReadDto UserName)
        {
            Action<UserReadDto>? handler = OnLoginSuccess;
            if (handler != null)
            {
                handler(UserName); // Raise the event with the parameter
            }
        }
        private async void btn_Login_Click(object sender, EventArgs e)
        {
            UserReadDto? user = (await _Login());

            if (user is not null)
            {
                if (OnLoginSuccess != null)
                {
                    LoginSuccess(user);
                }
            }
        }

        private async Task<UserReadDto?> _Login()
        {
            string userName = tb_UserName.Text;
            string pinCode = tb_PinCode.Text;

            UserReadDto? user = await UserApi.Login(userName, pinCode);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
