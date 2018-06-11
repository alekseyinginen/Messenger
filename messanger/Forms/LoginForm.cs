using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.ApiClient;


namespace Messenger.Forms
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        private readonly MessengerApiClient apiClient;

        private bool isLoginProcessRunning = false;

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

            if (!isLoginProcessRunning)
            {
                isLoginProcessRunning = true;
                bool isComplited = Task.Run(() => TryToLogin(username, password)).Result;
                if (isComplited)
                {
                    ShowClientForm();
                }
                else
                {
                    UsernameInput.Text = "";
                    PasswordInput.Text = "";
                    ErrorMessageLable.Text = "Username or password are incorrect";
                }
            }
            
        }

        private async Task<bool> TryToLogin(string username, string password)
        {
            var response = await apiClient.Login(username, password);
            isLoginProcessRunning = false;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private void ShowClientForm()
        {
            ClientForm clientForm = new ClientForm();
            clientForm.FormClosed += (s, args) => //???
            {
                clientForm.Dispose();
                if (args.CloseReason == CloseReason.UserClosing)
                {
                    this.Close();
                }
                else
                {
                    this.Show();
                }
            };
            clientForm.ShowDialog();
        }
    }
}
