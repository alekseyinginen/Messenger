using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.ApiClient;
using System.Threading;

namespace Messenger.Forms
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        MessengerApiClient apiClient;

        public LoginForm(string username, string password)
        {
            InitializeComponent();
            apiClient = MessengerApiClient.GetInstance();
            UsernameInput.Text = username;
            PasswordInput.Text = password;
        }

        private void RegisterClickEvent(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            Hide();
            registerForm.FormClosed += (s, args) => this.Show();
            registerForm.ShowDialog();
        }

        private void LoginClickEvent(object sender, EventArgs e)
        {
            string username = UsernameInput.Text;
            string password = PasswordInput.Text;
            Task.Factory.StartNew(() => TryToLogin(username, password)).Wait();
        }

        private async Task TryToLogin(string username, string password)
        {
            var response = await apiClient.Login(username, password);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("Darova petuh");
            }
            else 
            {
                ErrorMessageLable.Text = "Username or password are incorrect";
            }
        }
        
    }
}
