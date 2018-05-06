using Messenger.Validation;
using Messenger.ApiClient;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Messenger.ApiClient.Services;
using System.IO;

namespace Messenger.Forms
{
    public partial class RegisterForm : MetroFramework.Forms.MetroForm
    {
        private readonly MessengerApiClient apiClient;
        private RegisterModelValidator registerValidator;
        private ImageService imageService;

        private bool isValidUsername = false;
        private bool isValidEmail = false;
        private bool isValidPassword = false, isRepeatPasswordTheSame = false;

        private string imageUrl;

        public RegisterForm()
        {
            InitializeComponent();
            imageUrl = "http://www.verspers.nl/workspace/assets/images/empty_profile.png";
            apiClient = MessengerApiClient.GetInstance();
            registerValidator = new RegisterModelValidator();
            imageService = new ImageService();
            SetDefaultImage(imageUrl);
        }

        private void SetDefaultImage(string url) 
        {
            using (Stream stream = imageService.DownloadImage(url)) 
            {
                pictureBox.Image = new Bitmap(stream);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void SetErrorProvider(ErrorProvider provider, Icon icon, Control control, string message) 
        {
            provider.Icon = icon;
            provider.BlinkRate = 0;
            provider.SetError(control, message);
        }

        private void SetErrorMessage(string message) 
        {
            ErrorMessageLable.Text = message;
        }

        private void UsernameInputTextChanged(object sender, EventArgs e)
        {
            if (!registerValidator.IsUsernameCorrect(UsernameInput.Text))
            {
                SetErrorProvider(
                    errorProvider1, 
                    Properties.Resources.cancel, 
                    UsernameInput, 
                    "Enter username");

                isValidUsername = false;
            }
            else
            {
                SetErrorProvider(
                    errorProvider1, 
                    Properties.Resources.accept, 
                    UsernameInput, 
                    "Ok");

                isValidUsername = true;
            }
        }

        private void EmailInputTextChanged(object sender, EventArgs e)
        {
            if (!registerValidator.IsEmailCorrect(EmailInput.Text))
            {
                SetErrorProvider(
                    errorProvider2, 
                    Properties.Resources.cancel, 
                    EmailInput, 
                    "Enter valid email address");

                isValidEmail = false;
            }
            else
            {
                SetErrorProvider(
                    errorProvider2,
                    Properties.Resources.accept,
                    EmailInput,
                    "Ok");

                isValidEmail = true;
            }
        }

        private void PasswordInputTextChanged(object sender, EventArgs e) {
            if (!registerValidator.IsPasswordCorrect(PasswordInput.Text)) {
                SetErrorProvider(
                    errorProvider3,
                    Properties.Resources.cancel,
                    PasswordInput,
                    "Password must be 8 characters or longer");

                isValidPassword = false;
            }
            else {
                SetErrorProvider(
                    errorProvider3,
                    Properties.Resources.accept,
                    PasswordInput,
                    "Ok");

                isValidPassword = true;
            }
            RepeatPasswordInputTextChanged(this, null);
        }

        private void RepeatPasswordInputTextChanged(object sender, EventArgs e)
        {
            if (RepeatPasswordInput.Text.Equals(PasswordInput.Text) && registerValidator.IsPasswordCorrect(RepeatPasswordInput.Text))
            {
                SetErrorProvider(
                    errorProvider4,
                    Properties.Resources.accept,
                    RepeatPasswordInput,
                    "Ok");

                isRepeatPasswordTheSame = true;
            }
            else
            {
                SetErrorProvider(
                    errorProvider4,
                    Properties.Resources.cancel,
                    RepeatPasswordInput,
                    "Passwords do not match");

                isRepeatPasswordTheSame = false;
            }
        }

        private void UploadImageClickEvent(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.BMP;*.IMG;*.JPG;*.GIF,*.PNG)|*.BMP;*.IMG;*.JPG;*.GIF,*.PNG|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK) {
                try {
                    pictureBox.Image = new Bitmap(dialog.FileName);
                }
                catch {
                    SetErrorMessage("Could not open chosen file");
                }
            }
        }

        private void RegisterButtonClickEvent(object sender, EventArgs e)
        {
            if (isValidUsername && isValidEmail && isValidPassword && isRepeatPasswordTheSame)
            {
                Task.Factory.StartNew(() => TryToRegister(
                    UsernameInput.Text, 
                    EmailInput.Text, 
                    imageUrl, 
                    PasswordInput.Text)).Wait();
            }
            else
            {
                SetErrorMessage("Please, fill the fields with correct data and then try again");
            }
        }

        private async Task TryToRegister(string username, string email, string pictureUrl, string password) 
        {
            var response = await apiClient.Register(username, email, pictureUrl, password);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Close();
            }
            else 
            {
                SetErrorMessage("username or email already in use or password is too weak");
            }
        }
    }
}
