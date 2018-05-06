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

namespace Messenger.Forms
{
    public partial class ClientForm : MetroFramework.Forms.MetroForm
    {
        public UserModel user;
        static TcpClient client;
        static NetworkStream stream;
        public ClientForm()
        {
            InitializeComponent();
            Chat.Enabled = false;
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
                //client.Connect(host, port);
                stream = client.GetStream();

                //string message = userName;
                //byte[] data = Encoding.Unicode.GetBytes(message);
                //stream.Write(data, 0, data.Length);

                Thread receiveThread1 = new Thread(new ThreadStart(ReceiveMessage));;
                Chat.Text = "Welcome, " + Environment.NewLine; ;//+ userName;
                receiveThread1.Start();
            }
            catch (Exception ex)
            {
                Chat.Text = ex.Message;
            }
        }
        // отправка сообщений
        private void SendMessage()
        {
            string message = MessageTextInput.Text;
            Chat.Text += message + Environment.NewLine;
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
        // получение сообщений
        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    Chat.Text += message + Environment.NewLine;//вывод сообщения
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Console.ReadLine();
                    Disconnect();
                }
                
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if (stream != null)
                stream.Close();//отключение потока
            if (client != null)
                client.Close();//отключение клиента
            Environment.Exit(0); //завершение процесса
            Close();
        }

        private void Chat_TextChanged(object sender, EventArgs e)
        {

        }


        private void textMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendButtonClick(sender, e);
                MessageTextInput.Clear();
            }
        }

        private void LogoutButtonClick(object sender, EventArgs e) {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Environment.Exit(0);
            Close();
        }
    }
}
