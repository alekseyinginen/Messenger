using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using Messenger.ApiClient.Models;
using Messenger.ApiClient;
using Messenger.ApiClient.Services;
using System.IO;
using System.Configuration;
using Messenger.ApiClient.Helpers;

namespace Messenger.Forms
{
    public partial class ClientForm : MetroFramework.Forms.MetroForm
    {
        MessengerApiClient apiClient;
        ImageService imageService;

        private string host;
        private int port;

        private UserModel user;
        static TcpClient client;
        static NetworkStream stream;
        public ClientForm()
        {
            InitializeComponent();
            apiClient = MessengerApiClient.GetInstance();
            imageService = new ImageService();
            Initialize();
            Task.Factory.StartNew(() => Startup()).Wait();
        }

        private void Initialize()
        {
            Chat.Enabled = false;
            host = ConfigurationManager.AppSettings.Get("Host");
            port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Port"));
        }

        private async Task Startup()
        {
            user = await apiClient.GetCurrentUser();
            UsernameLable.Text = user.Username;
            SetUserImage(user.PictureURL);
            MainChat();
        }

        private void SetUserImage(string url)
        {
            using (Stream stream = imageService.DownloadImage(url))
            {
                pictureBox.Image = new Bitmap(stream);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void SendButtonClick(object sender, EventArgs e)
        {
            SendMessage();
            MessageTextInput.Clear();
        }
        
        private void MainChat()
        {
            client = new TcpClient();
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();

                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));;
                Chat.Text = "Welcome, " + user.Username + Environment.NewLine; ;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                Chat.Text = ex.Message;
            }
        }

        private void SendMessage()
        {
            
            MessageModel messageModel = GetMessageModel(MessageTextInput.Text);
            string json = JsonFormatter.Serialize(messageModel);
            byte[] data = Encoding.UTF8.GetBytes(json);
            stream.Write(data, 0, data.Length);
            ParseJsonAndShowMessage(json);
        }

        private MessageModel GetMessageModel(string messageText)
        {
            return new MessageModel
            {
                MessageText = messageText,
                SenderUsername = user.Username,
                PublishTime = DateTime.Now
            };
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string json = builder.ToString();
                    ParseJsonAndShowMessage(json);
                }
                catch
                {
                    Disconnect();
                }
                
            }
        }

        private void ParseJsonAndShowMessage(string json)
        {
            MessageModel message = JsonFormatter.Deserialize<MessageModel>(json);
            Chat.Text += message.SenderUsername + ": " + message.MessageText;
        }

        private void MessageTextInputOnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendButtonClick(sender, e);
                MessageTextInput.Clear();
            }
        }

        private void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Task.Factory.StartNew(() => Logout()).Wait();
            Close();
        }

        private void LogoutButtonClick(object sender, EventArgs e) {
            Disconnect();
        }

        private async Task Logout()
        {
            await apiClient.Logout();
        }
    }
}
