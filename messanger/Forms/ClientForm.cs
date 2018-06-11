using System;
using System.Collections.Generic;
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
using Messenger.SignalRClient;

namespace Messenger.Forms
{
    public partial class ClientForm : MetroFramework.Forms.MetroForm, IDisposable
    {
        MessengerApiClient apiClient;
        ImageService imageService;

        private string host;
        private int port;
        private Thread receiveThread;

        private UserModel currentUser;
        private List<GroupModel> userGroups;
        private GroupModel currentGroup;

        static TcpClient client;
        static NetworkStream stream;

        public ClientForm()
        {
            InitializeComponent();
            apiClient = MessengerApiClient.GetInstance();
            imageService = new ImageService();
           
            Initialize();
            Task.Run(() => Startup()).Wait();
        }

        private void GetChatHistory(Func<IEnumerable<MessageModel>, IEnumerable<MessageModel>> sortFunc)
        {
            currentGroup = userGroups.FirstOrDefault(x => x.Usernames.Contains(ComboBoxActiveGroup.SelectedItem as string));

            if (currentGroup != null)
            {
                List<MessageModel> messages = Task.Run(() => apiClient.GetMessages(currentGroup.GroupId)).Result;
                messages = sortFunc(messages).ToList();
                foreach (var message in messages)
                {
                    AppendMessageToChat(message);
                }
            }
        }
         
        private void Initialize()
        {
            host = ConfigurationManager.AppSettings.Get("Host");
            port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Port"));
        }

        private async Task Startup()
        {   
            currentUser = await apiClient.GetCurrentUser();
            UsernameLable.Text = currentUser.Username;
            SetUserImage(currentUser.PictureURL);

            userGroups = Task.Run(() => GetAllUserGroups()).Result;
            currentUser.GroupIds = userGroups.Select(x => x.GroupId).ToList();

            var groupNames = userGroups.Select(g => g.Usernames.First(u => u != currentUser.Username)).ToList();
            FillGroups(groupNames);

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
        
        private void MainChat()
        {
            client = new TcpClient();
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();

                GetTransportModelAndSend("userConnected", currentUser);

                receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                Chat.Text += Environment.NewLine + "\t\tWelcome, " + currentUser.Username + Environment.NewLine;
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                Chat.Text = ex.Message;
            }
        }

        private void GetTransportModelAndSend<T>(string method, T data)
            where T : class
        {
            var transportModel = new TransportModel { Method = method, JsonData = JsonFormatter.Serialize(data) };

            string json = JsonFormatter.Serialize(transportModel);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            stream.Write(bytes, 0, bytes.Length);
        }

        private void SendMessage()
        {
            if (currentGroup != null)
            {
                MessageModel messageModel = GetMessageModel(MessageTextInput.Text);

                GetTransportModelAndSend("addMessage", messageModel);
                AppendMessageToChat(messageModel);
            }
            //Task.Factory.StartNew(() => apiClient.AddMessage(messageModel)).Wait();
        }

        private MessageModel GetMessageModel(string messageText)
        {
            return new MessageModel
            {
                MessageText = messageText,
                SenderUsername = currentUser.Username,
                PublishTime = DateTime.Now,
                GroupId = currentGroup.GroupId
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
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string json = builder.ToString();
                    ParseJsonAndShowMessage(json);
                }
                catch
                {
                    Dispose();
                }
                
            }
        }

        private void ParseJsonAndShowMessage(string json)
        {
            var transportModel = JsonFormatter.Deserialize<TransportModel>(json);

            var message = JsonFormatter.Deserialize<MessageModel>(transportModel.JsonData);

            if (transportModel.Method == "addMessage")
            {
                if (message.GroupId == currentGroup.GroupId)
                {
                    AppendMessageToChat(message);
                }
            }
            else if(transportModel.Method == "userConnected" || transportModel.Method == "userDisconnected")
            {
                MessageBox.Show(message.MessageText);
            }
        }

        private void AppendMessageToChat(MessageModel message)
        {
            string username = "";
            if (!string.IsNullOrEmpty(message.SenderUsername))
            {
                username = message.PublishTime.ToShortTimeString() + " " + message.SenderUsername + ": ";
            }

            Chat.Text += username + message.MessageText + Environment.NewLine;
        }

        private void MessageTextInputOnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (MessageTextInput.Text != "") SendMessage();
                MessageTextInput.Clear();
            }
        }

        private void SendMesseges_MouseClick(object sender, KeyEventArgs e)
        {
            SendMessage();
            MessageTextInput.Clear();
        }

        private void LogoutButtonClick(object sender, EventArgs e) {
            Close();
        }

        private async Task Logout()
        {
            await apiClient.Logout();
        }

        public new void Dispose()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            if (receiveThread != null)
                receiveThread.Abort();
            
            Task.Factory.StartNew(() => Logout()).Wait();
        }

        private void Chat_TextChanges(object sender, EventArgs e)
        {
            Chat.SelectionStart = Chat.Text.Length;
            Chat.ScrollToCaret();
            Chat.Refresh();
        }

        private void Setting_MouseDowm(object sender, MouseEventArgs e)
        {
            SortBox.Visible = true;
        }

        private void SortBox_Leave(object sender, EventArgs e)
        {
            SortBox.Visible = false;
        }

        private void SendMesseges_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageTextInput.Text != "")
            {
                SendMessage();
            }
            MessageTextInput.Clear();
        }

        private void ByNameCheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonByName.Checked)
            {
                SearchForm searchForm = new SearchForm(searchText =>
                {
                    if (!searchText.Equals(string.Empty))
                    {
                        Chat.Clear();
                        GetChatHistory(messages => messages.Where(m => m.SenderUsername.Contains(searchText)));
                    }
                });
                searchForm.ShowDialog();
            }
        }

        private void ByDateCheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonByDate.Checked)
            {
                Chat.Clear();
                GetChatHistory(messages => messages);
            }
        }

        private void ByContextCheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonByContext.Checked)
            {
                SearchForm searchForm = new SearchForm(searchText =>
                {
                    if (!searchText.Equals(string.Empty))
                    {
                        Chat.Clear();
                        GetChatHistory(messages => messages.Where(m => m.MessageText.Contains(searchText)));
                    }
                });
                searchForm.ShowDialog();
            }
        }

        private void SearchForUserButton_Click(object sender, EventArgs e)
        {
            var query = SearchTextBox.Text;

            if (!string.IsNullOrEmpty(query))
            {
                var users = Task.Run(() => MakeApiQueryToSearchForUsers(query)).Result;
                if (users.Count > 0)
                {
                    UserChoose userChoose = new UserChoose(users);

                    userChoose.FormClosing += (s, args) =>
                    {
                        string chosenUser = userChoose.GetUser();
                        if (!string.IsNullOrEmpty(chosenUser))
                        {
                            var group = Task.Run(() => CreateGroup(chosenUser)).Result;

                            if (group != null)
                            {
                                ComboBoxActiveGroup.Items.Add(chosenUser);
                                userGroups.Add(group);
                                if (currentGroup == null)
                                {
                                    currentGroup = group;
                                }
                            }
                        }
                    };

                    userChoose.ShowDialog();
                }
                else
                {
                    MessageBox.Show("users not found");
                }
            }
        }

        private async Task<List<UserModel>> MakeApiQueryToSearchForUsers(string query)
        {
            return await apiClient.SearchForUsers(query);
        }

        private async Task<GroupModel> CreateGroup(string username)
        {
            GroupModel group = new GroupModel
            {
                Usernames = new List<string>()
            };

            group.Usernames.Add(currentUser.Username);
            group.Usernames.Add(username);

            return await apiClient.CreateGroup(group);
        }

        private async Task<List<GroupModel>> GetAllUserGroups()
        {
            return await apiClient.GetAllUserGroups();
        }

        private void FillGroups(List<string> groupNames)
        {
            foreach (var name in groupNames)
            { 
                ComboBoxActiveGroup.Items.Add(name);
            }

            if (groupNames.Count != 0)
            {
                ComboBoxActiveGroup.SelectedIndex = 0;
            }
        }

        private void ComboBoxActiveGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetChatHistory((messages) => messages);
        }
    }
}
