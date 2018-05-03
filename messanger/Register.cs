using Messenger.Validation;
using Messenger.ApiClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger
{
    public partial class Register : MetroFramework.Forms.MetroForm
    {
        private readonly MessengerApiClient apiClient;
        private RegisterModelValidator registerValidator;

        public int n = 0;
        public Register()
        {
            InitializeComponent();
            apiClient = MessengerApiClient.GetInstance();
            registerValidator = new RegisterModelValidator();

        }
        public bool NameA = false, IsUsernameValid = false, Password = false, CheckPassword = false;

        private void BoxName_TextChanged(object sender, EventArgs e)
        {
            if (!registerValidator.IsUsernameCorrect(UsernameInput.Text))
            {
                errorProvider1.Icon = Properties.Resources.cancel;
                errorProvider1.BlinkRate = 0;
                errorProvider1.SetError(UsernameInput, "Enter username");
                NameA = false;
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.accept;
                errorProvider1.BlinkRate = 0;
                errorProvider1.SetError(UsernameInput, "Ok");
                NameA = true;
            }
        }

        private void BoxNickTextChanged(object sender, EventArgs e)
        {
            if (!registerValidator.IsEmailCorrect(EmailInput.Text))
            {
                errorProvider2.Icon = Properties.Resources.cancel;
                errorProvider2.BlinkRate = 0;
                errorProvider2.SetError(EmailInput, "Enter valid email address");
                IsUsernameValid = false;
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.accept;
                errorProvider2.BlinkRate = 0;
                errorProvider2.SetError(EmailInput, "Ok");
                IsUsernameValid = true;
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.IMG;*.JPG;*.GIF,*.PNG)|*.BMP;*.IMG;*.JPG;*.GIF,*.PNG|All files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл","Ошибка");
                }
            }
        }

        private void BoxRepeatPassTextChanged(object sender, EventArgs e)
        {
            int a = String.Compare(RepeatPasswordInput.Text, PasswordInput.Text);
            if (a == 0)
            {
                errorProvider4.Icon = Properties.Resources.accept;
                errorProvider4.BlinkRate = 0;
                errorProvider4.SetError(RepeatPasswordInput, "Ok");
                CheckPassword = true;
            }
            else
            {
                errorProvider4.Icon = Properties.Resources.cancel;
                errorProvider4.BlinkRate = 0;
                errorProvider4.SetError(RepeatPasswordInput, "Passwords do not match");
                CheckPassword = false;
            }
        }

        private void BoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (!registerValidator.IsPasswordCorrect(PasswordInput.Text))
            {
                errorProvider3.Icon = Properties.Resources.cancel;
                errorProvider3.BlinkRate = 0;
                errorProvider3.SetError(PasswordInput, "password is to small");
                Password = false;
            }
            else
            {
                errorProvider3.Icon = Properties.Resources.accept;
                errorProvider3.BlinkRate = 0;
                errorProvider3.SetError(PasswordInput, "Ok");
                Password = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameA && IsUsernameValid && Password && CheckPassword)
            {
                 Register(UsernameInput.Text, EmailInput.Text, PasswordInput.Text);

                this.Close();
            }
            else
            {
                MessageBox.Show("Some fields are not correct");
            }
        }
    }
}
